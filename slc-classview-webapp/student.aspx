<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/default.master" CodeBehind="student.aspx.cs" Inherits="SLC_Classview_CSharp.student" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Student</h2>
        <asp:DetailsView ID="studentDetailView" runat="server" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="name.firstName" HeaderText="First Name" />
                <asp:BoundField DataField="name.lastSurname" HeaderText="Last Name" />
                <asp:BoundField DataField="birthData.birthDate" HeaderText="Birth Date" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>

        <br />
        <strong>Student Notes:</strong><br />
        <br />
        <asp:TextBox ID="studentNotesTextBox" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
        <br />

        </asp:Content>