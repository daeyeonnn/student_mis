﻿Public Class frmEdit
    Public Sub addCombo()
        'add item for college
        cboEditCollege.Items.Add("College of Agriculture")
        cboEditCollege.Items.Add("College of Arts and Sciences")

        'add item for course
        cboEditCourse.Items.Add("Bachelor of Science in Information Technology")
        cboEditCourse.Items.Add("Bachelor of Science in Computer Science")

        'add item for gender
        cboEditGender.Items.Add("Male")
        cboEditGender.Items.Add("Female")

    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Try
            DBConnect()
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tblstudent SET student_id = '" & txtEditID.Text.ToString.Trim & "', name = '" & txtEditName.Text.ToString.Trim & "', college = '" & cboEditCollege.Text.ToString & "', course = '" & cboEditCourse.Text.ToString & "', age = '" & txtEditAge.Text.ToString.Trim & "', gender = '" & cboEditGender.Text.ToString & "', phone_number = '" & txtEditPhone.Text.ToString.Trim & "', address = '" & txtEditAddress.Text.ToString.Trim & "' WHERE id = '" & frmMain.DataGridView1.Item("Column9", frmMain.DataGridView1.CurrentRow.Index).Value & "';"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            DBClose()

            MessageBox.Show("Successfully Updated Record", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            frmMain.loadData()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

End Class