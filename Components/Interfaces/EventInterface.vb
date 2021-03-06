﻿' --- Copyright (c) notice NevoWeb ---
'  Copyright (c) 2010 SARL NevoWeb.  www.nevoweb.com. BSD License.
' Author: D.C.Lee
' ------------------------------------------------------------------------
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' ------------------------------------------------------------------------
' This copyright notice may NOT be removed, obscured or modified without written consent from the author.
' --- End copyright notice --- 



Imports System.Runtime.Remoting
Imports NEvoWeb.Modules.NB_Store.SharedFunctions

Namespace NEvoWeb.Modules.NB_Store


    Public MustInherit Class EventInterface

#Region "Shared/Static Methods"

        ' singleton reference to the instantiated object 
        Private Shared objProvider As EventInterface = Nothing

        ' constructor
        Shared Sub New()
            CreateProvider()
        End Sub

        ' dynamically create provider
        Private Shared Sub CreateProvider()
            Dim handle As ObjectHandle
            Dim Prov As String()
            Dim ProviderName As String

            ProviderName = GetStoreSetting(CType(HttpContext.Current.Items("PortalSettings"), DotNetNuke.Entities.Portals.PortalSettings).PortalId, "event.provider")
            If ProviderName <> "" Then
                Prov = Split(ProviderName, ",")
                handle = Activator.CreateInstance(Prov(0), Prov(1))
                objProvider = DirectCast(handle.Unwrap, EventInterface)
            End If
        End Sub

        ' return the provider
        Public Shared Shadows Function Instance() As EventInterface
            Return objProvider
        End Function

#End Region

        Public Overridable Sub CreateOrder(ByVal PortalID As Integer, ByVal OrderID As Integer)
        End Sub
        Public Overridable Sub EditOrderUpdate(ByVal PortalID As Integer, ByVal OrderID As Integer)
        End Sub
        Public Overridable Sub AddItemToCart(ByVal PortalID As Integer, ByVal CartItemID As Integer)
        End Sub
        Public Overridable Sub DisplayProduct(ByVal PortalID As Integer, ByVal ProductID As Integer, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo)
        End Sub
        Public Overridable Sub AddToWishList(ByVal PortalID As Integer, ByVal ProductID As Integer, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo)
        End Sub
        Public Overridable Sub DownloadDocument(ByVal PortalID As Integer, ByVal DocID As Integer, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo)
        End Sub
        Public Overridable Sub CompletedOrder(ByVal PortalID As Integer, ByVal OrderType As Integer, ByVal OrderID As Integer)
        End Sub
        Public Overridable Sub AutoResponse(ByVal PortalID As Integer, ByVal Request As System.Web.HttpRequest)
        End Sub
        Public Overridable Function getSettingTextName(ByVal PortalID As Integer, ByVal SettingName As String, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo) As String
            Return SettingName
        End Function
        Public Overridable Function getSettingName(ByVal PortalID As Integer, ByVal SettingName As String, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo) As String
            Return SettingName
        End Function
        Public Overridable Function getCategoryMessage(ByVal PortalID As Integer, ByVal CategoryID As Integer, ByVal UserInfo As DotNetNuke.Entities.Users.UserInfo) As String
            Return ""
        End Function

    End Class

End Namespace
