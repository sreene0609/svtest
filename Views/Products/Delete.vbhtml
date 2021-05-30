@ModelType svstore2.product
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
