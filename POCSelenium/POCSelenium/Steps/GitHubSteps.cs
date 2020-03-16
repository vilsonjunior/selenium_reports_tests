using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using POCSelenium.Common;
using System;
using TechTalk.SpecFlow;

namespace POCSelenium.Steps
{
    [Binding]
    public class GitHubSteps : BaseDriver
    {
        public GitHubSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [Given(@"que acesse a url '(.*)'")]
        public void DadoQueAcesseAUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
        }
        
        [When(@"preencher o campo '(.*)' com '(.*)'")]
        public void QuandoPreencherOCampoCom(string campo, string valor)
        {
            var element = 
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(campo)));
            base.HighlightElement(element);
            element.SendKeys(valor);
        }
        
        [When(@"clicar no botão '(.*)'")]
        public void QuandoClicarNoBotao(string nomeBotao)
        {
            var element = _driver.FindElement(By.XPath($"//input[@name='{nomeBotao}']"));
            base.HighlightElement(element);
            element.Click();
        }
        
        [Then(@"deve exibir a mensagem '(.*)'")]
        public void EntaoDeveExibirAMensagem(string texto)
        {
            var element = _driver.FindElement(By.XPath($"//div[@id='js-flash-container']"));            
            base.HighlightElement(element);
            Assert.AreEqual(texto, element.Text);            
        }
    }
}
