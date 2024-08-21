using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC1.Models;

namespace CC1.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 33, CountryName = "INDIA", Capital = "NEW DELHI" },
            new Country { ID = 77, CountryName = "CHINA", Capital = "BEIJING" },
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> GetAllCountries()
        {
            return countries;
        }

        [HttpGet]
        [Route("Bymsg")]
        public HttpResponseMessage GetCountriesWithMessage()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countries);
            return response;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryById(int pId)
        {
            Country country = countries.SingleOrDefault(c => c.ID == pId);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country.CountryName);
        }

        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostCountry([FromBody] Country country)
        {
            countries.Add(country);
            return countries;
        }

        [HttpPost]
        [Route("countrypost")]
        public IEnumerable<Country> PostCountryByParams([FromUri] int Id, string name, string capital)
        {
            Country country = new Country
            {
                ID = Id,
                CountryName = name,
                Capital = capital
            };
            countries.Add(country);
            return countries;
        }

        [HttpPut]
        public IHttpActionResult PutCountry(int pid, [FromBody] Country updatedCountry)
        {
 
            Country existingCountry = countries.FirstOrDefault(c => c.ID == pid);
            if (existingCountry == null)
            {
                return NotFound();
            }
            existingCountry.CountryName = updatedCountry.CountryName;
            existingCountry.Capital = updatedCountry.Capital;

            return Ok(existingCountry);
        }

        [HttpDelete]
        [Route("delcountry")]
        public IEnumerable<Country> DeleteCountry(int pid)
        {
            Country countryToRemove = countries.SingleOrDefault(c => c.ID == pid);
            if (countryToRemove != null)
            {
                countries.Remove(countryToRemove);
            }
            return countries;
        }
    }
}