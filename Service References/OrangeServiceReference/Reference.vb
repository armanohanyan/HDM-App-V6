﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34209
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace OrangeServiceReference
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OrangeServiceReference.IClientServerConnecter")>  _
    Public Interface IClientServerConnecter
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClientServerConnecter/GetLogData", ReplyAction:="http://tempuri.org/IClientServerConnecter/GetLogDataResponse")>  _
        Function GetLogData() As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClientServerConnecter/CleanUpLog", ReplyAction:="http://tempuri.org/IClientServerConnecter/CleanUpLogResponse")>  _
        Function CleanUpLog() As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClientServerConnecter/CheckGprsStatus", ReplyAction:="http://tempuri.org/IClientServerConnecter/CheckGprsStatusResponse")>  _
        Function CheckGprsStatus(ByVal gprs As String) As String
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IClientServerConnecterChannel
        Inherits OrangeServiceReference.IClientServerConnecter, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class ClientServerConnecterClient
        Inherits System.ServiceModel.ClientBase(Of OrangeServiceReference.IClientServerConnecter)
        Implements OrangeServiceReference.IClientServerConnecter
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetLogData() As String Implements OrangeServiceReference.IClientServerConnecter.GetLogData
            Return MyBase.Channel.GetLogData
        End Function
        
        Public Function CleanUpLog() As Boolean Implements OrangeServiceReference.IClientServerConnecter.CleanUpLog
            Return MyBase.Channel.CleanUpLog
        End Function
        
        Public Function CheckGprsStatus(ByVal gprs As String) As String Implements OrangeServiceReference.IClientServerConnecter.CheckGprsStatus
            Return MyBase.Channel.CheckGprsStatus(gprs)
        End Function
    End Class
End Namespace
