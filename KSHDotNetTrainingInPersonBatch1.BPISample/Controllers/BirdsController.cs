using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace KSHDotNetTrainingInPersonBatch1.BPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            var result = GetBirds();
            return Ok(result.Tbl_Bird);
        }
        
        [HttpGet("MyanmarName/{BirdMyanmarName}/EnglishName/{BirdEnglishName}")]
        public IActionResult BirdName(string BirdMyanmarName, string BirdEnglishName)
        {
            var result = GetBirds();
            var item = result.Tbl_Bird.FirstOrDefault(x =>
            x.BirdMyanmarName == BirdMyanmarName ||
            x.BirdEnglishName == BirdEnglishName);
            return Ok(item);
        }

        //[HttpGet("BirdName")]
        //public IActionResult BirdName(string BirdMyanmarName, string BirdEnglishName)
        //{
        //    var result = GetBirds();

        //    var item = result.Tbl_Bird.FirstOrDefault(x =>
        //        (!string.IsNullOrEmpty(BirdMyanmarName) && x.BirdMyanmarName == BirdMyanmarName) ||
        //        (!string.IsNullOrEmpty(BirdEnglishName) && x.BirdEnglishName == BirdEnglishName));

        //    return Ok(item);
        //}



        private BirdsResponseModel GetBirds()
        {
            string fileName = "Birds.json";
            string json = System.IO.File.ReadAllText(fileName);
            // json to .net newton object
            var result = JsonConvert.DeserializeObject<BirdsResponseModel>(json)!;
            return result;
        }
    }


    public class BirdsResponseModel
    {
        public Tbl_Bird[] Tbl_Bird { get; set; }
    }

    public class Tbl_Bird
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

}
