using PaymentGateway.Helpers;
using PaymentGateway.Models;
using System.Text.Json;

namespace PaymentGateway.Services
{

    public interface ITransactionService
    {
        ResponseModel PerformTransaction(string transactionRequest);
    }
    public class TransactionService : ITransactionService
    {

        #region Services Initilization
        private readonly IEncryptionHelper _encryptionHelper;
        #endregion
        public TransactionService(IEncryptionHelper encryptionHelper)
        {
            _encryptionHelper = encryptionHelper;
        }

       
        /// <summary>
        /// Perform Transation
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// <returns></returns>

        public ResponseModel PerformTransaction(string transactionRequest)
        {
            try
            {
                #region Decrypt Request
                var decrytedRequest = _encryptionHelper.Decrypt(transactionRequest);
                #endregion
                var transactionData = JsonSerializer.Deserialize<TransactionModel>(decrytedRequest);

                if (transactionData != null)
                    return new ResponseModel()
                    {
                        ResponseCode = new Random().Next(0, 1000),
                        ApprovalCode = new Random().Next(0, 1000000).ToString("D6"),
                        DateTime = DateTime.UtcNow,
                        Message = "Transaction processed successfully"
                    };

               
            }
            catch (Exception ex)
            {

               
            }

            return new ResponseModel()
            {
                ResponseCode = 0,
                ApprovalCode = "000000",
                DateTime = DateTime.UtcNow,
                Message = "Somethin went wrong"
            };
        }

        #region Helper Methods

        #endregion
    }
}
