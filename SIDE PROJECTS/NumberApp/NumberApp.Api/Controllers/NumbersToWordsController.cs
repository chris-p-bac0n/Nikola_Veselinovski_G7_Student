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

        [HttpGet]
        public string GetWordsFromNumber([FromBody] UserInput userInput)
        {
            try
            {
                var result = _numbersToWordsService.ConvertNumbersToWords(userInput.Input);
                return result;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return ex.Message;
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("vice-versa")]
        public string GetNumberFromWords([FromBody] UserInput userInput)
        {
            try
            {
                var result = _wordsToNumbersService.ConvertWordsToNumbers(userInput.Input);
                return result.ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return ex.Message;
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
    }
}
