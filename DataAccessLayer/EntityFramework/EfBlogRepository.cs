﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
{
    public List<Blog> GetListWithCategory()
    {
        using (var c = new Context())
        {
            return c.Blogs.Include(x => x.Category).ToList(); //include eklendi
        }
    }

    public List<Blog> GetListWithCategoryByWriter(int id)
    {
        using (var c = new Context())
        {
            return c.Blogs.Include(x => x.Category).Where(x => x.WriterId == id).ToList(); //include eklendi
        }
    }
}