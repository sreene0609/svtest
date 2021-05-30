@ModelType IEnumerable(Of svstore2.product)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.prodname)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.qty)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.price)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.brand.brand1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.category.category1)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.prodname)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.qty)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.price)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.brand.brand1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.category.category1)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.id })
        </td>
    </tr>
Next

</table>
