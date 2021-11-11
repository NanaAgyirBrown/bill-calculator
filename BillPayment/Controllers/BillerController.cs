using BillPayment.Data.Validations;
using BillPayment.Domain;
using BillPayment.Domain.Models;
using BillPayment.Helpers;
using BillPayment.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BillPayment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Description("Biller Rest API")]
    public class BillerController : ControllerBase
    {
        // Repository
        private readonly IBillerRepository _billerRepository;

        // Logger
        private readonly ILogger<BillerController> _logger;

        // Instance
        private readonly ItemValidation _validateItem;
        private readonly CartValidation _validateCart;
        private readonly Responses _responses;
        private readonly BillCalculator _billCalculator;

        public BillerController(ILogger<BillerController> logger, ILogger<BillCalculator> loggerCal, IBillerRepository billerRepository,ILogger<ItemValidation> itemLogger, ILogger<CartValidation> cartLogger)
        {
            _logger = logger;
            _billerRepository = billerRepository;

            _validateItem = new ItemValidation(itemLogger);
            _validateCart = new CartValidation(cartLogger);

            _responses = new Responses();
            _billCalculator = new BillCalculator(_billerRepository, loggerCal);

            _logger.Log(LogLevel.Information, "Billing Controller initialized.");
        }

        /// <summary>
        /// Get a list of item category
        /// </summary>
        /// <returns>
        /// ItemReponses
        /// </returns>
        [HttpGet("GetItemCategories")]
        public async Task<ApiResponse> GetCategory()
        {
            _logger.LogInformation("Retrieving category for items.....");
            var message = new BindingList<string>();

            try
            {                
                var category = _billerRepository.GetItemsCategories;  

                if (category is EmptyResult)
                    message.Add("No category available. Add items");

                message.Add("Category attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, category);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }

        /// <summary>
        /// Get a list of Saved items
        /// </summary>
        /// <returns>
        /// ItemReponses
        /// </returns>
        [HttpGet("GetShopItems")]
        public async Task<ApiResponse> GetItems()
        {
            _logger.LogInformation("Retrieving list of shop items.....");
            var message = new BindingList<string>();

            try
            {
                var items = _billerRepository.GetItems;

                if (items is EmptyResult)
                    message.Add("No items available. Add items");

                message.Add("Shop items attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, items);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }

        /// <summary>
        /// Returns list of User Types
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserTypes")]
        public async Task<ApiResponse> GetUserType()
        {
            _logger.LogInformation("Retrieving list of user types..........");
            var message = new BindingList<string>();

            try
            {
                var usersTypes = _billerRepository.GetUserTypes;

                if (usersTypes is EmptyResult)
                    message.Add("No users types available.");

                message.Add("User types list attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, usersTypes);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }

        /// <summary>
        /// Returns list of how discount rules applies
        /// </summary>
        /// <returns>
        /// ApiResponse
        /// </returns>
        [HttpGet("GetRulesAppliesTo")]
        public async Task<ApiResponse> GetRuleApplies()
        {
            _logger.LogInformation("Retrieving discount types..........");
            var message = new BindingList<string>();

            try
            {                
                var discountApplies = _billerRepository.GetRulesApplication;

                if (discountApplies is EmptyResult)
                    message.Add("No discount application rule found.");

                message.Add("Discount Rules list attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, discountApplies);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }

        /// <summary>
        /// Returns list of Discount Types
        /// </summary>
        /// <returns>
        /// ApiResponse
        /// </returns>
        [HttpGet("GetDiscountTypes")]
        public async Task<ApiResponse> GetDiscountTypes()
        {
            _logger.LogInformation("Retrieving discount types..........");
            var message = new BindingList<string>();

            try
            {                
                var discountTypes = _billerRepository.GetDiscountsTypes;

                if (discountTypes is EmptyResult)
                    message.Add("No discount types found.");

                message.Add("Discount Rules list attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, discountTypes);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }


        /// <summary>
        /// Returns list of Discount Rules
        /// </summary>
        /// <returns>
        /// ApiResponse
        /// </returns>
        [HttpGet("GetDiscounts")]
        public async Task<ApiResponse> GetDiscountRules()
        {
            _logger.LogInformation("Retrieving discount rules..........");
            var message = new BindingList<string>();

            try
            {
                var discountRules = _billerRepository.GetDiscountRules;

                if (discountRules is EmptyResult)
                    message.Add("No discount rules found.");

                message.Add("Discount Rules list attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, discountRules);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }

        /// <summary>
        /// Get a list of Saved Users 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetShopUsers")]
        public async Task<ApiResponse> GetUsers()
        {
            _logger.LogInformation("Retrieving list of registered users..........");
            var message = new BindingList<string>();

            try
            {
                var users = _billerRepository.GetUsers;

                if (users is EmptyResult)
                    message.Add("No users registered.");


                message.Add("User list attached");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, users);
            }
            catch (Exception ex)
            {
                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }

        }


        [HttpPost("ShopingCart")]
        public async Task<ApiResponse> MyShopingCart([FromBody]Cart cart)
        {
            _logger.LogWarning("Validating User's Cart....");
            var message = _validateCart.validateObject(cart);

            try
            {         
                if (message.Count > 0)
                    return await _responses.GetResponse(OperationActions.Failed, BillerStatus.Fetched, message, null);

                // Calculator
                var calculatedBill = _billCalculator.GetBill(cart);
                
                if (calculatedBill is null || calculatedBill.BillId == Guid.Empty)
                {
                    message.Add("Invoice could not be calculated.");
                    return await _responses.GetResponse(OperationActions.Failed, BillerStatus.Fetched, message, calculatedBill);
                }
                    

                message.Add("Invoice attached.");
                return await _responses.GetResponse(OperationActions.Success, BillerStatus.Fetched, message, calculatedBill);
            }
            catch (Exception ex)
            {

                message.Add($"{ "Server Error "} : { ex.Message } ");
                return await _responses.GetResponse(OperationActions.Exception, BillerStatus.Crashed, message, null);
            }
        }
    }
}