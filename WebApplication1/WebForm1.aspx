<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Front_Office.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                TempData["test"] = "regis";

                Response.Write(TempData["test"]);

                HttpCookie ck = new HttpCookie("testcookie");
                ck.Value = "regis";
                ck.Expires = new DateTime().AddDays(10);
                Response.Cookies.Add(ck);

                Response.Write("fin");
            %>
        </div>
    </form>
</body>
</html>
