﻿using Appium.Integration.Tests.Helpers;
using Appium.Integration.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using System;

namespace Appium.Integration.Tests.PageObjectTests.Android
{
    [TestFixture()]
    public class AndroidTestThatChecksAttributeMix3SelendroidMode
    {
        private AndroidDriver<AppiumWebElement> driver;
        private AndroidPageObjectChecksSelendroidModeOnNativeApp pageObject;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            AppiumOptions capabilities =
                Caps.getSelendroid19Caps(Apps.get("selendroidTestApp"));
            if (Env.isSauce())
            {
                capabilities.AddAdditionalCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.AddAdditionalCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.AddAdditionalCapability("name", "android - complex");
                capabilities.AddAdditionalCapability("tags", new string[] {"sample"});
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIAndroid;
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Context = "NATIVE_APP";
            TimeOutDuration timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 0, 5, 0));
            pageObject = new AndroidPageObjectChecksSelendroidModeOnNativeApp();
            PageFactory.InitElements(driver, pageObject, new AppiumPageObjectMemberDecorator(timeSpan));
        }

        [OneTimeTearDown]
        public void AfterEach()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            if (!Env.isSauce())
            {
                AppiumServers.StopLocalService();
            }
        }

        [Test()]
        public void CheckMobileElement()
        {
            Assert.NotNull(pageObject.GetMobileElementText());
        }

        [Test()]
        public void CheckMobileElements()
        {
            Assert.GreaterOrEqual(pageObject.GetMobileElementSize(), 1);
        }

        [Test()]
        public void CheckMobileElementProperty()
        {
            Assert.NotNull(pageObject.GetMobileElementPropertyText());
        }

        [Test()]
        public void CheckMobileElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMobileElementPropertySize(), 1);
        }

        [Test()]
        public void CheckElementFoundUsingMultipleLocators()
        {
            Assert.NotNull(pageObject.GetMultipleFindByElementText());
        }

        [Test()]
        public void CheckElementsFoundUsingMultipleLocators()
        {
            Assert.GreaterOrEqual(pageObject.GetMultipleFindByElementSize(), 1);
        }

        [Test()]
        public void CheckElementFoundUsingMultipleLocatorsProperty()
        {
            Assert.NotNull(pageObject.GetMultipleFindByElementPropertyText());
        }

        [Test()]
        public void CheckElementsFoundUsingMultipleLocatorssProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMultipleFindByElementPropertySize(), 1);
        }

        [Test()]
        public void CheckElementFoundByChainedSearch()
        {
            Assert.NotNull(pageObject.GetFoundByChainedSearchElementText());
        }

        [Test()]
        public void CheckElementsFoundByChainedSearch()
        {
            Assert.GreaterOrEqual(pageObject.GetFoundByChainedSearchElementSize(), 1);
        }

        [Test()]
        public void CheckFoundByChainedSearchElementProperty()
        {
            Assert.NotNull(pageObject.GetFoundByChainedSearchElementPropertyText());
        }

        [Test()]
        public void CheckFoundByChainedSearchElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetFoundByChainedSearchElementPropertySize(), 1);
        }

        [Test()]
        public void CheckElementMatchedToAll()
        {
            Assert.NotNull(pageObject.GetMatchedToAllLocatorsElementText());
        }

        [Test()]
        public void CheckElementsMatchedToAll()
        {
            Assert.GreaterOrEqual(pageObject.GetMatchedToAllLocatorsElementSize(), 1);
            Assert.LessOrEqual(pageObject.GetMatchedToAllLocatorsElementSize(), 2);
        }

        [Test()]
        public void CheckElementMatchedToAllProperty()
        {
            Assert.NotNull(pageObject.GetMatchedToAllLocatorsElementPropertyText());
        }

        [Test()]
        public void CheckElementMatchedToAllElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMatchedToAllLocatorsElementPropertySize(), 1);
            Assert.LessOrEqual(pageObject.GetMatchedToAllLocatorsElementPropertySize(), 2);
        }
    }
}