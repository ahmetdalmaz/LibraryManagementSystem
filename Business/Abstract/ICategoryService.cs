﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        List<Category> GetAll();
        void Delete(Category category);
        Category GetById(int id);
        void Update(Category category);
    }
}
