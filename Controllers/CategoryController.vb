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
    Public Class CategoryController
        Inherits System.Web.Mvc.Controller

        Private db As New svstoreEntities

        ' GET: Category
        Function Index() As ActionResult
            Return View(db.categories.ToList())
        End Function

        ' GET: Category/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' GET: Category/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Category/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,category1")> ByVal category As category) As ActionResult
            If ModelState.IsValid Then
                db.categories.Add(category)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(category)
        End Function

        ' GET: Category/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' POST: Category/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,category1")> ByVal category As category) As ActionResult
            If ModelState.IsValid Then
                db.Entry(category).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(category)
        End Function

        ' GET: Category/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' POST: Category/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim category As category = db.categories.Find(id)
            db.categories.Remove(category)
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
