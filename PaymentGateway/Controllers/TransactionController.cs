using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Helpers;
using PaymentGateway.Models;
using PaymentGateway.Services;
using System.Text.Json;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        #region Service initilization
        private readonly IEncryptionHelper _encryptionHelper;
        private readonly ITransactionService _transactionService;
        #endregion
        public TransactionController(IEncryptionHelper encryptionHelper, ITransactionService transactionService)
        {
            _encryptionHelper = encryptionHelper;
            _transactionService = transactionService;
        }



        [HttpGet("encryption-key")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetEncryptionKey()
        {
            return Ok(_encryptionHelper.GetEncryptionKey());
        }

        [HttpPost("process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult ProcessTransaction([FromBody] string transactionRequest)
        {
            var response = _transactionService.PerformTransaction(transactionRequest);
            return Ok(response);
        }


        [HttpGet("Encrypt")]
        public string EncryptData(string text)
        {
            var encryptedTrRequest = new TransactionModel
            {
                ProcessingCode = "222",
                SystemTrace = "2222",
                CardHolder = "Abc12333",
                CurrencyCode = 222,
                CardNumber = "11111111111222",
                FunctionCode = "222",
                TransactionAmount = 1222
            };
            text = JsonSerializer.Serialize(encryptedTrRequest);
            var encryptedText = _encryptionHelper.Encrypt(text);
            return encryptedText;
        }

        [HttpGet("Decrypt")]
        public string DecryptData(string text)
        {
            var decryptedText = _encryptionHelper.Decrypt(text);
            return decryptedText;
        }
    }
}


