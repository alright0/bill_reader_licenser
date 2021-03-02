Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' сохранение файла лицензии. Можно сохранять с любым именем

        ' функция добавляет дополнительное значение к хэшу FeatureSet(central processor)
        Dim outputlic As String = TextBox1.Text & "FFFFFF"

        SaveFileDialog1.Filter = "license files (*.lic)|*.lic"

        ' сохранение хэша с расширением lic
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText _
             (SaveFileDialog1.FileName, GetHash(outputlic), False)
        End If

    End Sub

    Shared Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
