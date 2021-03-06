﻿Imports System.Data.SqlClient



Public Module SQLConnectionMOD
    Public SQL As String
    Public conn As SqlConnection
    Public Server As String
    Public DataBase1 As String
    Public Password As String
    Public Function GetConnect() As Boolean
        Try
            conn = New SqlConnection("Data Source= 192.168.180.9\flat; Initial Catalog= ; User Id = melekhin; Password = me1ekhin;")
            conn.Open()
            Return 1
        Catch ex As Exception
            MsgBox("Ошибка подключения к SQL сервер. " & ex.Message)
            Return 0
        End Try
    End Function

    Public Sub LoadGridFromDB(ByVal Grid1 As DataGridView, cmd As String)
        GetConnect()
        Try
            Dim c As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet

            c = conn.CreateCommand
            c.CommandText = cmd

            da.SelectCommand = c
            da.Fill(ds, "Table1")

            Grid1.DataSource = ds
            Grid1.DataMember = "Table1"
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub RunCommand(cmd As String)
        GetConnect()
        Try
            Dim c As New SqlCommand
        c = conn.CreateCommand
        c.Connection = conn
        c.CommandType = CommandType.Text
        c.CommandText = cmd
        c.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Function SelectString(cmd As String) As String
        GetConnect()
        Try
            Dim c As New SqlCommand
            Dim r As SqlDataReader
            Dim k As String
            k = ""
            c = conn.CreateCommand
            c.CommandType = CommandType.Text
            c.CommandText = cmd

            r = c.ExecuteReader
            If r.Read Then
                k = r.Item(0)
                r.Close()
            End If

            Return k
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Function

    Public Function SelectFloat(cmd As String) As Double
        GetConnect()
        Try
            Dim c As New SqlCommand
            Dim r As SqlDataReader
            Dim k As Double

            c = conn.CreateCommand
            c.CommandType = CommandType.Text
            c.CommandText = cmd

            r = c.ExecuteReader
            If r.Read Then
                k = r.Item(0)
                r.Close()
            End If

            Return k
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Function


    Public Function SelectBoolean(cmd As String) As Boolean
        GetConnect()
        Try
            Dim c As New SqlCommand
            Dim r As SqlDataReader
            Dim k As Boolean

            c = conn.CreateCommand
            c.CommandType = CommandType.Text
            c.CommandText = cmd

            r = c.ExecuteReader
            If r.Read Then
                k = r.Item(0)
                r.Close()
            End If

            Return k
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Function

    Public Function SelectByte(cmd As String) As Byte()
        GetConnect()
        Try
            Dim c As New SqlCommand
            Dim r As SqlDataReader
            Dim k() As Byte

            c = conn.CreateCommand
            c.CommandType = CommandType.Text
            c.CommandText = cmd

            r = c.ExecuteReader
            If r.Read Then
                k = r.Item(0)
                r.Close()
            End If

            Return k
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Function


End Module
