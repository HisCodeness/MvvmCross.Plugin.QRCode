using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Plugin.QrCode.UnitTest.Fakes;

namespace MvvmCross.Plugin.QrCode.UnitTest
{
    [TestClass]
    public class BaseMvxQrCodeTest
    {
        [TestMethod]
        public async Task NullResultTest()
        {
            AssertScanResult(await ScanExecute<MvxQrCodeNull>(), ScanStatus.Canceled);
        }

        [TestMethod]
        public async Task DefaultResultTest()
        {
            AssertScanResult(await ScanExecute<MvxQrCodeDefault>(), ScanStatus.Canceled, string.Empty);
        }

        [TestMethod]
        public async Task SuccessResultTest()
        {
            AssertScanResult(await ScanExecute<MvxQrCodeSuccess>(), ScanStatus.Success, MvxQrCodeSuccess.ResultLabel);
        }

        [TestMethod]
        public async Task ErrorResultTest()
        {
            AssertScanResult(await ScanExecute<MvxQrCodeError>(), ScanStatus.Error, MvxQrCodeError.ErrorLabel);
        }

        /// <summary>
        /// Execute the scan of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private async Task<ScanResult> ScanExecute<T>() where T : IMvxQrCode, new()
        {
            var instance = new T();
            return await instance.Scan(default, default, default);
        }

        /// <summary>
        /// Assert scan result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="expectedStatus"></param>
        private void AssertScanResult(ScanResult result, ScanStatus expectedStatus)
        {
            AssertScanResult(result, expectedStatus, default, default);
        }

        /// <summary>
        /// Assert scan result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="expectedStatus"></param>
        private void AssertScanResult(ScanResult result, ScanStatus expectedStatus, string expectedLabel)
        {
            if (expectedStatus == ScanStatus.Error)
            {
                AssertScanResult(result, expectedStatus, default, expectedLabel);
            }
            else
            {
                AssertScanResult(result, expectedStatus, expectedLabel, default);
            }
        }

        /// <summary>
        /// Assert scan result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="expectedStatus"></param>
        private void AssertScanResult(ScanResult result, ScanStatus expectedStatus, string expectedSuccessLabel, string expectedErrorLabel)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedStatus, result.ScanStatus);

            if (expectedSuccessLabel == default)
            {
                Assert.IsNull(result.Result);
            }
            else
            {
                Assert.AreEqual(expectedSuccessLabel, result.Result.Text);
            }

            if (string.IsNullOrEmpty(expectedErrorLabel))
            {
                Assert.IsNull(result.Exception);
            }
            else
            {
                Assert.AreEqual(expectedErrorLabel, result.Exception.Message);
            }
        }
    }
}
