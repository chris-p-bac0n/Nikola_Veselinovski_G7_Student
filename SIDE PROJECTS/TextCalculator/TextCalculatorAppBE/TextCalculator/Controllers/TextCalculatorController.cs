using Microsoft.AspNetCore.Mvc;
using TextCalculatorApp.Services.Interfaces;
using System;
using TextCalculatorApp.Api.ViewModels;

namespace TextCalculatorApp.Api.Controllers
{
    [Route("api/text-calculator")]
    [ApiController]
    public class TextCalculatorController : ControllerBase
    {
        private readonly ITextCalculator _textCalculatorService;
        public TextCalculatorController(ITextCalculator textCalculatorService)
        {
            _textCalculatorService = textCalculatorService;
        }

        [HttpPost]
        public object GetSumFromInputNumbers([FromBody] UserInput userInput)
        {
            try
            {
                var result = _textCalculatorService.Add(userInput.Input);
                return new { result };
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return new { result = ex.ParamName };
            }
            catch (InvalidOperationException ex)
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
