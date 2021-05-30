@ModelType svstore2.category
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>category</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.category1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.category1)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
