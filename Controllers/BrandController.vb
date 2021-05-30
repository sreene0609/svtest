Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports svstore2

Namespace Controllers
    Public Class BrandController
        Inherits System.Web.Mvc.Controller

        Private db As New svstoreEntities

        ' GET: Brand
        Function Index() As ActionResult
            Return View(db.brands.ToList())
        End Function

        ' GET: Brand/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim brand As brand = db.brands.Find(id)
            If IsNothing(brand) Then
                Return HttpNotFound()
            End If
            Return View(brand)
        End Function

        ' GET: Brand/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Brand/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,brand1")> ByVal brand As brand) As ActionResult
            If ModelState.IsValid Then
                db.brands.Add(brand)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(brand)
        End Function

        ' GET: Brand/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim brand As brand = db.brands.Find(id)
            If IsNothing(brand) Then
                Return HttpNotFound()
            End If
            Return View(brand)
        End Function

        ' POST: Brand/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,brand1")> ByVal brand As brand) As ActionResult
            If ModelState.IsValid Then
                db.Entry(brand).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(brand)
        End Function

        ' GET: Brand/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim brand As brand = db.brands.Find(id)
            If IsNothing(brand) Then
                Return HttpNotFound()
            End If
            Return View(brand)
        End Function

        ' POST: Brand/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim brand As brand = db.brands.Find(id)
            db.brands.Remove(brand)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
