namespace Binance.Spot.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Wallet_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region SystemStatus
        [Fact]
        public async void SystemStatus_Response()
        {
            var responseContent = "{\"status\":0,\"msg\":\"normal\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/system/status", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.SystemStatus();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AllCoinsInformation
        [Fact]
        public async void AllCoinsInformation_Response()
        {
            var responseContent = "[{\"coin\":\"BTC\",\"depositAllEnable\":true,\"free\":\"0.08074558\",\"freeze\":\"0.00000000\",\"ipoable\":\"0.00000000\",\"ipoing\":\"0.00000000\",\"isLegalMoney\":false,\"locked\":\"0.00000000\",\"name\":\"Bitcoin\",\"networkList\":[{\"addressRegex\":\"^(bnb1)[0-9a-z]{38}$\",\"coin\":\"BTC\",\"depositDesc\":\"Wallet Maintenance, Deposit Suspended\",\"depositEnable\":false,\"isDefault\":false,\"memoRegex\":\"^[0-9A-Za-z\\-_]{1,120}$\",\"minConfirm\":1,\"name\":\"BEP2\",\"network\":\"BNB\",\"resetAddressStatus\":false,\"specialTips\":\"Both a MEMO and an Address are required to successfully deposit your BEP2-BTCB tokens to Binance.\",\"unLockConfirm\":0,\"withdrawDesc\":\"Wallet Maintenance, Withdrawal Suspended\",\"withdrawEnable\":false,\"withdrawFee\":\"0.00000220\",\"withdrawIntegerMultiple\":\"0.00000001\",\"withdrawMax\":\"9999999999.99999999\",\"withdrawMin\":\"0.00000440\",\"sameAddress\":true},{\"addressRegex\":\"^[13][a-km-zA-HJ-NP-Z1-9]{25,34}$|^(bc1)[0-9A-Za-z]{39,59}$\",\"coin\":\"BTC\",\"depositEnable\":true,\"isDefault\":true,\"memoRegex\":\"\",\"minConfirm\":1,\"name\":\"BTC\",\"network\":\"BTC\",\"resetAddressStatus\":false,\"specialTips\":\"\",\"unLockConfirm\":2,\"withdrawEnable\":true,\"withdrawFee\":\"0.00050000\",\"withdrawIntegerMultiple\":\"0.00000001\",\"withdrawMax\":\"750\",\"withdrawMin\":\"0.00100000\",\"sameAddress\":false}],\"storage\":\"0.00000000\",\"trading\":true,\"withdrawAllEnable\":true,\"withdrawing\":\"0.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/config/getall", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.AllCoinsInformation();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DailyAccountSnapshot
        [Fact]
        public async void DailyAccountSnapshot_Response()
        {
            var responseContent = "{\"code\":200,\"msg\":\"\",\"snapshotVos\":[{\"data\":{\"balances\":[{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"},{\"asset\":\"USDT\",\"free\":\"1.89109409\",\"locked\":\"0.00000000\"}],\"totalAssetOfBtc\":\"0.09942700\"},\"type\":\"spot\",\"updateTime\":1576281599000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/accountSnapshot", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.DailyAccountSnapshot(AccountType.SPOT);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DisableFastWithdrawSwitch
        [Fact]
        public async void DisableFastWithdrawSwitch_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/account/disableFastWithdrawSwitch", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.DisableFastWithdrawSwitch();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableFastWithdrawSwitch
        [Fact]
        public async void EnableFastWithdrawSwitch_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/account/enableFastWithdrawSwitch", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.EnableFastWithdrawSwitch();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region Withdraw
        [Fact]
        public async void Withdraw_Response()
        {
            var responseContent = "{\"id\":\"7213fea8e94b4a5593d507237e5a555b\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/withdraw/apply", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.Withdraw("BNB", "1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv", 2.1m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DepositHistory
        [Fact]
        public async void DepositHistory_Response()
        {
            var responseContent = "[{\"amount\":\"0.00999800\",\"coin\":\"PAXG\",\"network\":\"ETH\",\"status\":1,\"address\":\"0x788cabe9236ce061e5a892e1a59395a81fc8d62c\",\"addressTag\":\"\",\"txId\":\"0xaad4654a3234aa6118af9b4b335f5ae81c360b2394721c019b5d1e75328b09f3\",\"insertTime\":1599621997000,\"transferType\":0,\"unlockConfirm\":\"12/12\",\"confirmTimes\":\"12/12\"},{\"amount\":\"0.50000000\",\"coin\":\"IOTA\",\"network\":\"IOTA\",\"status\":1,\"address\":\"SIZ9VLMHWATXKV99LH99CIGFJFUMLEHGWVZVNNZXRJJVWBPHYWPPBOSDORZ9EQSHCZAMPVAPGFYQAUUV9DROOXJLNW\",\"addressTag\":\"\",\"txId\":\"ESBFVQUTPIWQNJSPXFNHNYHSQNTGKRVKPRABQWTAXCDWOAKDKYWPTVG9BGXNVNKTLEJGESAVXIKIZ9999\",\"insertTime\":1599620082000,\"transferType\":0,\"unlockConfirm\":\"1/12\",\"confirmTimes\":\"1/1\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/hisrec", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.DepositHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region WithdrawHistory
        [Fact]
        public async void WithdrawHistory_Response()
        {
            var responseContent = "[{\"address\":\"0x94df8b352de7f46f64b01d3666bf6e936e44ce60\",\"amount\":\"8.91000000\",\"applyTime\":\"2019-10-12 11:12:02\",\"coin\":\"USDT\",\"id\":\"b6ae22b3aa844210a7041aee7589627c\",\"withdrawOrderId\":\"WITHDRAWtest123\",\"network\":\"ETH\",\"transferType\":0,\"status\":6,\"transactionFee\":\"0.004\",\"confirmNo\":3,\"txId\":\"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268\"},{\"address\":\"1FZdVHtiBqMrWdjPyRPULCUceZPJ2WLCsB\",\"amount\":\"0.00150000\",\"applyTime\":\"2019-09-24 12:43:45\",\"coin\":\"BTC\",\"id\":\"156ec387f49b41df8724fa744fa82719\",\"network\":\"BTC\",\"status\":6,\"transactionFee\":\"0.004\",\"transferType\":0,\"confirmNo\":2,\"txId\":\"60fd9007ebfddc753455f95fafa808c4302c836e4d1eebc5a132c36c1d8ac354\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/withdraw/history", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.WithdrawHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DepositAddress
        [Fact]
        public async void DepositAddress_Response()
        {
            var responseContent = "{\"address\":\"1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv\",\"coin\":\"BTC\",\"tag\":\"\",\"url\":\"https://btc.com/1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/address", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.DepositAddress("BNB");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AccountStatus
        [Fact]
        public async void AccountStatus_Response()
        {
            var responseContent = "{\"data\":\"Normal\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/account/status", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.AccountStatus();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AccountApiTradingStatus
        [Fact]
        public async void AccountApiTradingStatus_Response()
        {
            var responseContent = "{\"data\":{\"isLocked\":false,\"plannedRecoverTime\":0,\"triggerCondition\":{\"GCR\":150,\"IFER\":150,\"UFR\":300},\"indicators\":{\"BTCUSDT\":[{\"i\":\"UFR\",\"c\":20,\"v\":0.05,\"t\":0.995},{\"i\":\"IFER\",\"c\":20,\"v\":0.99,\"t\":0.99},{\"i\":\"GCR\",\"c\":20,\"v\":0.99,\"t\":0.99}],\"ETHUSDT\":[{\"i\":\"UFR\",\"c\":20,\"v\":0.05,\"t\":0.995},{\"i\":\"IFER\",\"c\":20,\"v\":0.99,\"t\":0.99},{\"i\":\"GCR\",\"c\":20,\"v\":0.99,\"t\":0.99}]},\"updateTime\":1547630471725}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/account/apiTradingStatus", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.AccountApiTradingStatus();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region Dustlog
        [Fact]
        public async void Dustlog_Response()
        {
            var responseContent = "{\"total\":8,\"userAssetDribblets\":[{\"operateTime\":1615985535000,\"totalTransferedAmount\":\"0.00132256\",\"totalServiceChargeAmount\":\"0.00002699\",\"transId\":45178372831,\"userAssetDribbletDetails\":[{\"transId\":4359321,\"serviceChargeAmount\":\"0.000009\",\"amount\":\"0.0009\",\"operateTime\":1615985535000,\"transferedAmount\":\"0.000441\",\"fromAsset\":\"USDT\"},{\"transId\":4359321,\"serviceChargeAmount\":\"0.00001799\",\"amount\":\"0.0009\",\"operateTime\":1615985535000,\"transferedAmount\":\"0.00088156\",\"fromAsset\":\"ETH\"}]},{\"operateTime\":1616203180000,\"totalTransferedAmount\":\"0.00058795\",\"totalServiceChargeAmount\":\"0.000012\",\"transId\":4357015,\"userAssetDribbletDetails\":[{\"transId\":4357015,\"serviceChargeAmount\":\"0.00001\",\"amount\":\"0.001\",\"operateTime\":1616203180000,\"transferedAmount\":\"0.00049\",\"fromAsset\":\"USDT\"},{\"transId\":4357015,\"serviceChargeAmount\":\"0.000002\",\"amount\":\"0.0001\",\"operateTime\":1616203180000,\"transferedAmount\":\"0.00009795\",\"fromAsset\":\"ETH\"}]}]}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/dribblet", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.Dustlog();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DustTransfer
        [Fact]
        public async void DustTransfer_Response()
        {
            var responseContent = "{\"totalServiceCharge\":\"0.02102542\",\"totalTransfered\":\"1.05127099\",\"transferResult\":[{\"amount\":\"0.03000000\",\"fromAsset\":\"ETH\",\"operateTime\":1563368549307,\"serviceChargeAmount\":\"0.00500000\",\"tranId\":2970932918,\"transferedAmount\":\"0.25000000\"},{\"amount\":\"0.09000000\",\"fromAsset\":\"LTC\",\"operateTime\":1563368549404,\"serviceChargeAmount\":\"0.01548000\",\"tranId\":2970932918,\"transferedAmount\":\"0.77400000\"},{\"amount\":\"248.61878453\",\"fromAsset\":\"TRX\",\"operateTime\":1563368549489,\"serviceChargeAmount\":\"0.00054542\",\"tranId\":2970932918,\"transferedAmount\":\"0.02727099\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/dust", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.DustTransfer(new string[] { "BTC", "USDT" });

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AssetDividendRecord
        [Fact]
        public async void AssetDividendRecord_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\"10.00000000\",\"asset\":\"BHFT\",\"divTime\":1563189166000,\"enInfo\":\"BHFT distribution\",\"tranId\":2968885920},{\"amount\":\"10.00000000\",\"asset\":\"BHFT\",\"divTime\":1563189165000,\"enInfo\":\"BHFT distribution\",\"tranId\":2968885920}],\"total\":2}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/assetDividend", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.AssetDividendRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AssetDetail
        [Fact]
        public async void AssetDetail_Response()
        {
            var responseContent = "{\"CTR\":{\"minWithdrawAmount\":\"70.00000000\",\"depositStatus\":false,\"withdrawFee\":35,\"withdrawStatus\":true,\"depositTip\":\"Delisted, Deposit Suspended\"},\"SKY\":{\"minWithdrawAmount\":\"0.02000000\",\"depositStatus\":true,\"withdrawFee\":0.01,\"withdrawStatus\":true}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/assetDetail", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.AssetDetail();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region TradeFee
        [Fact]
        public async void TradeFee_Response()
        {
            var responseContent = "[{\"symbol\":\"ADABNB\",\"makerCommission\":\"0.001\",\"takerCommission\":\"0.001\"},{\"symbol\":\"BNBBTC\",\"makerCommission\":\"0.001\",\"takerCommission\":\"0.001\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/tradeFee", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.TradeFee();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region UserUniversalTransfer
        [Fact]
        public async void UserUniversalTransfer_Response()
        {
            var responseContent = "{\"tranId\":13526853623}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.UserUniversalTransfer(UniversalTransferType.MAIN_UMFUTURE, "BNB", 2.1m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryUserUniversalTransferHistory
        [Fact]
        public async void QueryUserUniversalTransferHistory_Response()
        {
            var responseContent = "{\"total\":2,\"rows\":[{\"asset\":\"USDT\",\"amount\":\"1\",\"type\":\"MAIN_UMFUTURE\",\"status\":\"CONFIRMED\",\"tranId\":11415955596,\"timestamp\":1544433328000},{\"asset\":\"USDT\",\"amount\":\"2\",\"type\":\"MAIN_UMFUTURE\",\"status\":\"CONFIRMED\",\"tranId\":11366865406,\"timestamp\":1544433328000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/transfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.QueryUserUniversalTransferHistory(UniversalTransferType.MAIN_UMFUTURE);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region FundingWallet
        [Fact]
        public async void FundingWallet_Response()
        {
            var responseContent = "[{\"asset\":\"USDT\",\"free\":\"1\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"btcValuation\":\"0.00000091\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/asset/get-funding-asset", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.FundingWallet();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetApiKeyPermission
        [Fact]
        public async void GetApiKeyPermission_Response()
        {
            var responseContent = "{\"ipRestrict\":false,\"createTime\":1623840271000,\"enableWithdrawals\":false,\"enableInternalTransfer\":true,\"permitsUniversalTransfer\":true,\"enableVanillaOptions\":false,\"enableReading\":true,\"enableFutures\":false,\"enableMargin\":false,\"enableSpotAndMarginTrading\":false,\"tradingAuthorityExpirationTime\":1628985600000}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/account/apiRestrictions", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Wallet wallet = new Wallet(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await wallet.GetApiKeyPermission();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}