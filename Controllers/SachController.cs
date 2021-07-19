using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab7.Controllers
{
    public class SachController : ApiController
    {
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.Saches.ToList();
        }
        [HttpGet]
        public Sach GetSach(int Id)
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.Saches.FirstOrDefault(x => x.Id == Id);
        }
        [HttpPost]
        public bool InsertNewSach(string title, string authorname, float price, string content)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = new Sach();
                sach.Title = title;
                sach.AuthorName = authorname;
                sach.Price = price;
                sach.Content = content;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateSach(int Id, string title, string authorname, float price, string content)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = db.Saches.FirstOrDefault(x => x.Id == Id);
                if (sach == null) return false;
                sach.Title = title;
                sach.AuthorName = authorname;
                sach.Price = price;
                sach.Content = content;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteSach(int Id)
        {
            DBSachDataContext db = new DBSachDataContext();
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == Id);
                if (sach == null) 
                return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
