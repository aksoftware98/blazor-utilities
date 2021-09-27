using System;
using System.Linq;
using BlazorUtilitiesSample.Shared;
using Bunit;
using Xunit;

namespace BlazorUtilitiesSample.Tests
{
    public class MessagingCenterComponents
    {
        public MessagingCenterComponents()
        {
        }

        [Fact]
        public void UpdateUsername_ShouldUpdateNavMenuUsername()
        {
            var testContext = new TestContext();
            var navMenuComponent = testContext.RenderComponent<NavMenu>();
            var firstAnchor = navMenuComponent.FindAll("a")[1];
            firstAnchor.MarkupMatches("<span class=\"oi oi - person\" aria-hidden=\"true\" b-g4ljmjz4uk=\"\"></span> Ahmad Mozaffar");
        }

    }
}
