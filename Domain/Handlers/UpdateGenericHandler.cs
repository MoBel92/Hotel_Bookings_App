﻿using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;

namespace StartMyNewApp.Domain.Handlers
{
    public class UpdateGenericHandler<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public UpdateGenericHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
