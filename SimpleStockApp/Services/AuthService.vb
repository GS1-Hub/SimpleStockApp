Imports System.Security.Cryptography
Imports System.Text

Public Class AuthService
    Private Shared Function HashPassword(password As String) As String
        Dim bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))
        Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
    End Function

    Public Shared Function Login(username As String, password As String) As User
        Dim hashedPassword = HashPassword(password)
        Dim dc1 As New AppDbContext()
        Dim user = dc1.Users.FirstOrDefault(Function(u) u.Username = username AndAlso u.Password = hashedPassword)
        Return user
    End Function

    Public Shared Function Register(user As User) As Boolean
        Dim dc1 As New AppDbContext()
        dc1.Users.Add(New User() With {
            .Username = user.Username,
            .Password = HashPassword(user.Password),
            .Email = user.Email,
            .IsClient = True
        })
        dc1.SaveChanges()
        Return True
    End Function
End Class