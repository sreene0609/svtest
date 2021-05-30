@ModelType svstore2.product
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>product</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.prodname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.prodname)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.qty)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.qty)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.price)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.price)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.brand.brand1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.brand.brand1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.category.category1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.category.category1)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
