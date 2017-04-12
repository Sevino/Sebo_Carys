<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Front_Office.WebForm2" %>

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
                if (TempData["test"] == null)
                    Response.Write("variable de session inconnue");
                else
                Response.Write(TempData["test"]);


                //Response.Write (  Request.Cookies["testcookie"].Value );
                %>
        </div>
    </form>
</body>
</html>
