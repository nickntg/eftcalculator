Imports System.Text
Imports EFTCalculator.Core

<TestClass()>
Public Class StorageUnitTests

    Const ONEVALUE As String = "0123456789ABCDEF"

    <TestMethod()>
    Public Sub TestReadStorage()

        Using SW As IO.StreamWriter = New IO.StreamWriter("KEYS.TXT", False, System.Text.Encoding.Default)
            SW.WriteLine("Test1;" + ONEVALUE + ";Test1")
            SW.WriteLine("Test2;" + ONEVALUE + ONEVALUE + ";Test2")
            SW.WriteLine("Test3;" + ONEVALUE + ONEVALUE + ONEVALUE + ";Test3")
        End Using

        KeyStore.Clear()
        KeyStore.ReadKeys()

        Dim SK As StoredKey = KeyStore.GetKey("Test1")
        Assert.AreEqual(ONEVALUE, SK.KeyValue)
        Assert.AreEqual("Test1", SK.KeyComment)

        SK = KeyStore.GetKey("Test2")
        Assert.AreEqual(ONEVALUE + ONEVALUE, SK.KeyValue)
        Assert.AreEqual("Test2", SK.KeyComment)

        SK = KeyStore.GetKey("Test3")
        Assert.AreEqual(ONEVALUE + ONEVALUE + ONEVALUE, SK.KeyValue)
        Assert.AreEqual("Test3", SK.KeyComment)
    End Sub

    <TestMethod()> _
    Public Sub TestWriteStorage()
        KeyStore.Clear()

        Dim sk1 As New StoredKey("Test1", ONEVALUE, "Test1")
        Dim sk2 As New StoredKey("Test2", ONEVALUE + ONEVALUE, "Test2")
        Dim sk3 As New StoredKey("Test3", ONEVALUE + ONEVALUE, "Test3")

        KeyStore.AddKey(sk1)
        KeyStore.AddKey(sk2)
        KeyStore.AddKey(sk3)

        KeyStore.WriteKeys()

        Using SR As IO.StreamReader = New IO.StreamReader("KEYS.TXT", System.Text.Encoding.Default)
            Assert.AreEqual(SR.ReadLine, sk1.ToString)
            Assert.AreEqual(SR.ReadLine, sk2.ToString)
            Assert.AreEqual(SR.ReadLine, sk3.ToString)
        End Using
    End Sub

End Class
