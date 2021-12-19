using Microsoft.AspNetCore.Mvc;
using NumberApp.Services.Interfaces;
using System;

namespace NumberApp.Api.Controllers
{
    [Route("api/numbers-to-words")]
    [ApiController]
    public class NumbersToWordsController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public string GetWordsFromNumber(int id) [FromRoute]
        //{
        //    return $"{id}";
        //}

        //[HttpGet]
        //public string GetWordsFromNumber([FromBody] Param input)
        //{
        //    return input.Input;
        //}

        //[HttpGet]
        //public string GetWordsFromNumber([FromQuery] string input)
        //{
        //    return input;
        //}

        //[HttpGet]
        //public string GetWordsFromNumber([FromHeader] string input)
        //{
        //    return input;
        //}

        private readonly INumbersToWords _numbersToWordsService;
        private readonly IWordsToNumbers _wordsToNumbersService;
        public NumbersToWordsController(INumbersToWords numbersToWordsService, IWordsToNumbers wordsToNumbersService)
        {
            _numbersToWordsService = numbersToWordsService;
            _wordsToNumbersService = wordsToNumbersService;
        }

        [HttpPost]
        public object GetWordsFromNumber([FromBody] UserInput userInput)
        {
            try
            {
                var result = _numbersToWordsService.ConvertNumbersToWords(userInput.Input);
                return new { result };
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return new { result = ex.Message };
            }
            catch (ArgumentException ex)
            {
                return new { result = ex.Message };
            }
        }

        [HttpPost("vice-versa")]
        public object GetNumberFromWords([FromBody] UserInput userInput)
        {
            try
            {
                var result = _wordsToNumbersService.ConvertWordsToNumbers(userInput.Input);
                return new { result = result.ToString() };
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return new { result = ex.Message };
            }
            catch (ArgumentException ex)
            {
                return new { result = ex.Message };
            }
        }
    }
}
