﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports svstore2

Namespace Controllers
    Public Class ProductsController
        Inherits System.Web.Mvc.Controller

        Private db As New svstoreEntities

        ' GET: Products
        Function Index() As ActionResult
            Dim products = db.products.Include(Function(p) p.brand).Include(Function(p) p.category)
            Return View(products.ToList())
        End Function

        ' GET: Products/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' GET: Products/Create
        Function Create() As ActionResult
            ViewBag.brand_id = New SelectList(db.brands, "id", "brand1")
            ViewBag.cat_id = New SelectList(db.categories, "id", "category1")
            Return View()
        End Function

        ' POST: Products/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,prodname,cat_id,brand_id,qty,price")> ByVal product As product) As ActionResult
            If ModelState.IsValid Then
                db.products.Add(product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.brand_id = New SelectList(db.brands, "id", "brand1", product.brand_id)
            ViewBag.cat_id = New SelectList(db.categories, "id", "category1", product.cat_id)
            Return View(product)
        End Function

        ' GET: Products/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            ViewBag.brand_id = New SelectList(db.brands, "id", "brand1", product.brand_id)
            ViewBag.cat_id = New SelectList(db.categories, "id", "category1", product.cat_id)
            Return View(product)
        End Function

        ' POST: Products/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,prodname,cat_id,brand_id,qty,price")> ByVal product As product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.brand_id = New SelectList(db.brands, "id", "brand1", product.brand_id)
            ViewBag.cat_id = New SelectList(db.categories, "id", "category1", product.cat_id)
            Return View(product)
        End Function

        ' GET: Products/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As product = db.products.Find(id)
            db.products.Remove(product)
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
