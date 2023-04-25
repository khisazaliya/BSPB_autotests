namespace BSPB_autotests
{
    [SetUpFixture]
    public sealed class GlobalTearDown
    {

        [OneTimeTearDown]
        public void QuitTest()
        {
            ApplicationManager.Instance.Stop();
        }
    }
}
