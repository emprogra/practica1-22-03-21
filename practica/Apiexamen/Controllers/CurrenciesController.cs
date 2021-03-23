using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Apiexamen.Models;

namespace Apiexamen.Controllers
{
    public class CurrenciesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Currencies
        public IQueryable<Currency> GetCurrencies()
        {
            return db.Currencies;
        }

        // GET: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult GetCurrency(double id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurrency(double id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.monto)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Currencies
        [ResponseType(typeof(Currency))]
        public IHttpActionResult PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.monto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = currency.monto }, currency);
        }

        // DELETE: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult DeleteCurrency(double id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            db.SaveChanges();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(double id)
        {
            return db.Currencies.Count(e => e.monto == id) > 0;
        }
    }
}