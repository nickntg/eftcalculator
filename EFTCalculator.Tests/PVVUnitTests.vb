Imports EFTCalculator.Core
Imports EFTCalculator.Core.Cryptography

<TestClass()>
Public Class PVVUnitTests

    <TestMethod()>
    Public Sub TestPVVGeneration()
        Assert.AreEqual("3306", Utility.GeneratePVV("5044070000253211", "1", "1234", New HexKey("91F8983761D9EAC4761FEC58FDF82A43")))
    End Sub

End Class
