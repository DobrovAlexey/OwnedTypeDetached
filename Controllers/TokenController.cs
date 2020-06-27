using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OwnedTypeDetached.Db;
using OwnedTypeDetached.Entities;

namespace OwnedTypeDetached.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TokenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public void Add()
        {
            Debug.WriteLine("Start method Add");

            var entity = new TokenEntity
            {
                Text = "Text",
                CreateDate = DateTime.Now,
                Extension = new Extension()
            };

            _context.Tokens.Add(entity);

            _context.SaveChanges();

            Debug.WriteLine("End method Add");
        }

        [HttpGet]
        public void AddOwned()
        {
            Debug.WriteLine("Start method AddOwned");

            var entity = _context.Tokens.FirstOrDefault();

            if (entity.Extension == null)
            {
                entity.Extension = new Extension();
                entity.Extension.CreateDate = DateTime.Now;
            }

            _context.SaveChanges();

            Debug.WriteLine("End method AddOwned");
        }

        [HttpGet]
        public void Change()
        {
            Debug.WriteLine("Start method Change");

            var entity = _context.Tokens.First();

            entity.Extension.CreateDate = DateTime.Now;
            entity.Text = "Change all";

            _context.Update(entity);

            _context.SaveChanges();

            Debug.WriteLine("End method Change");
        }

        [HttpGet]
        public void ChangeEntity()
        {
            Debug.WriteLine("Start method ChangeEntity");

            var entity = _context.Tokens.FirstOrDefault();

            entity.CreateDate = DateTime.Now;
            entity.Text = "Change Entity";

            _context.SaveChanges();

            Debug.WriteLine("End method ChangeEntity");
        }

        [HttpGet]
        public void ChangeOwnedEntity()
        {
            Debug.WriteLine("Start method ChangeOwnedEntity");

            var entity =  _context.Tokens.FirstOrDefault();


            if (entity.Extension != null)
            {
                entity.Extension.CreateDate = DateTime.Now;
            }


            _context.SaveChanges();

            Debug.WriteLine("End method ChangeOwnedEntity");
        }

        [HttpGet]
        public void Delete()
        {
            Debug.WriteLine("Start method Delete");

            var entity = _context.Tokens.FirstOrDefault();

            _context.Tokens.Remove(entity);

            _context.SaveChanges();

            Debug.WriteLine("End method Delete");
        }
    }
}