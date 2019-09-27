using iHotel.Entity.Common;
using iHotel.Entity.Helper;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.SignalRHub;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IHotelDbContext db;
        private DbSet<T> entities;
        private readonly AppHub<T> orgHub;

        public Repository(IHotelDbContext context, AppHub<T> orgHub)
        {
            db = context;
            entities = context.Set<T>();
            this.orgHub = orgHub;
        }

        public async Task<int> CountAsync()
        {
            return await entities.CountAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity to save must not be null.");
            }
            //db.Attach(entity).State = EntityState.Added;
            var savedData = db.Add(entity).Entity;

            await db.SaveChangesAsync();

            List<T> dataToBroadcast = new List<T>() {
                savedData
            };
            await orgHub.Send(
                SignalRSignalTypes.Added,
                new HubResponse<T>()
                {
                    Data = dataToBroadcast,
                    HubDataState = HubDataState.Added
                }
            );

            return savedData;
        }

        public async Task<List<T>> CreateRangeAsync(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("Entitys to save must not be null.");
            }
            if (entities.Count <= 0)
            {
                throw new InvalidDataException("Entitys to save must contain atlest one entity. No entity is supplied.");
            }

            await db.AddRangeAsync(entities);
            await db.SaveChangesAsync();

            await orgHub.Send(SignalRSignalTypes.Added, new HubResponse<T>()
            {
                Data = entities,
                HubDataState = HubDataState.Added
            });

            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Supplied data is not valid. Supplied data is null. Entity of type {typeof(T).Name} is required.");
            }
            if (entity.Id <= 0)
            {
                throw new InvalidDataException($"Supplied data is not valid. Id is not valid. Property 'Id' of Entity of type {typeof(T).Name} must be greater than zero(0).");
            }
            db.Attach(entity).State = EntityState.Modified;

            //var virtualProps = entity.GetType().GetProperties().Where(ep => ep.GetGetMethod().IsVirtual).ToList();
            //virtualProps.ForEach(vp =>
            //{
            //    db.Attach(vp).State = EntityState.Modified;
            //});

            await db.SaveChangesAsync();

            List<T> dataToBroadcast = new List<T>() {
                entity
            };

            await orgHub.Send(
                SignalRSignalTypes.Updated, 
                new HubResponse<T>()
                {
                    Data = dataToBroadcast,
                    HubDataState = HubDataState.Edited
                });

            return entity;
        }

        public async Task<List<T>> UpdateRangeAsync(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Supplied data is not valid. List is null. List of Entities of type {typeof(T).Name} is required.");
            }
            if (entities.Count <= 0)
            {
                throw new InvalidDataException($"Supplied data is not valid. List is empty. List of Entities of type {typeof(T).Name} is required.");
            }
            if (entities.Where(entity => entity.Id <= 0).ToList().Count > 0)
            {
                throw new InvalidDataException($"Supplied data is not valid. Value for One or more than one id is less than or equals to zero(0). Entity of type {typeof(T).Name} with valid none zero(0) and greater than zero(0) value is required as 'Id'.");
            }

            //entities.ForEach(es => {
            //    db.Attach(es).State = EntityState.Modified;
            //    var virtualProps = es.GetType().GetProperties().Where(ep => ep.GetGetMethod().IsVirtual).ToList();
            //    virtualProps.ForEach(vp => {
            //        db.Attach(vp).State = EntityState.Modified;
            //    });
            //});
            //db.Attach(entities).State = EntityState.Modified;

            db.UpdateRange(entities);

            await db.SaveChangesAsync();

            await orgHub.Send(
                SignalRSignalTypes.Updated,
                new HubResponse<T>()
                {
                    Data = entities,
                    HubDataState = HubDataState.Edited
                }
            );

            return entities;
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public IQueryable<T> Get()
        {
            return GetAll().Where(es => es.IsActive == true);
        }

        public async Task<T> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than zero.");
            }
            //return entities.SingleOrDefault(e => e.Id == id);
            return await Get().Where(e => e.IsActive && e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> InactivateAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException($"Value of supplied Id is not valid. Id of entity of type {typeof(T).Name} must be greater than zero(0) to 'Trash' any data from database.");
            }

            T dataFromDb = await entities.FirstOrDefaultAsync(e => e.Id == id);
            dataFromDb.IsActive = false;
            return await UpdateAsync(dataFromDb);
        }

        public async Task<List<T>> InactivateRangeAsync(List<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException($"Supplied data is not valid. List of id are null. List of id of type {typeof(T).Name} are required in order to trash range of data from database.");
            }
            if (ids.Count <= 0)
            {
                throw new InvalidDataException($"List of id has zero(0) elements. List of id of type {typeof(T).Name} is required in order to trash range of data from database.");
            }
            if (ids.Where(id => id <= 0).ToList().Count > 0)
            {
                throw new InvalidDataException($"Supplied data is not valid. Value for One or more than one id is less than or equals to zero(0).  List of none zero id of type {typeof(T).Name} is required in order to trash range of data from database.");
            }

            List<T> dataFromDb = await entities.Where(e => ids.Contains(e.Id)).ToListAsync();
            dataFromDb.ForEach(data => data.IsActive = false);
            return await UpdateRangeAsync(dataFromDb);
        }

        public async Task<T> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException($"Value of supplied Id is not valid. Id of entity of type {typeof(T).Name} must be greater than zero(0) to 'Delete' any data from database.");
            }

            T dataToDelete = (T)Activator.CreateInstance(typeof(T));
            dataToDelete.Id = id;
            T deletedData = entities.Remove(dataToDelete).Entity;
            await db.SaveChangesAsync();
            return deletedData;
        }

        public async Task<List<T>> DeleteRangeAsync(List<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException($"Supplied argument is not valid. List of id are null. List of id of type {typeof(T).Name} are required in order to delete range of data from database.");
            }
            if (ids.Count <= 0)
            {
                throw new InvalidDataException($"List of id has zero(0) elements. List of id of type {typeof(T).Name} is required in order to delete range of data from database.");
            }
            if (ids.Where(id => id <= 0).ToList().Count > 0)
            {
                throw new InvalidDataException($"Supplied data is not valid. Value for One or more than one id is less than or equals to zero(0).  List of none zero id of type {typeof(T).Name} is required in order to delete range of data from database.");
            }

            List<T> lisOfDataToDelete = new List<T>();
            ids.ForEach(id => {
                T dataToDelete = (T)Activator.CreateInstance(typeof(T));
                dataToDelete.Id = id;
                lisOfDataToDelete.Add(dataToDelete);
            });
            entities.RemoveRange(lisOfDataToDelete);
            await db.SaveChangesAsync();
            return lisOfDataToDelete;
        }
        
    }
}
