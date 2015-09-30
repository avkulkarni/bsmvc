# bsmvc

An extension html (razor) helper that can be used in ASP .Net MVC projects for cration of grid which is based on 
[Bootstrap Table](http://bootstrap-table.wenzhixin.net.cn).

## How to use

- Add referance  to *bsmvc.dll* (present in "/dist/release" folder of this project) into your project.
- Make sure that all the css and js required are included in the page. This extension needs following css and js files.

```
<link rel="stylesheet" href="~/Content/bootstrap.min.css">
<link rel="stylesheet" href="~/Content/bootstrap-table/bootstrap-table.min.css">

<script src="~/Scripts/jquery.js"></script>
<script src="~/Scripts/bootstrap.js"></script>
<script src="~/Scripts/bootstrap-table/bootstrap-table.min.js"></script>
```

- If you need extensions support which is present in [Bootstrap Table](http://bootstrap-table.wenzhixin.net.cn), 
then you need to include those extension specific js and css files as well.

- Then simply use the syntax given below :

```
@(Html.BsMvc().Grid("someId12").Columns(new List<Column>{
        new Column("Id").Field("id").Class("col-xs-3"),
        new Column("Name").Field("name").Class("col-xs-3"),
        new Column("Price").Field("price").Class("col-xs-3")
    })
    .Height(400)
    .Url("/Home/GetData")
    .Pagination()
    .ShowColumns(true)
    .ShowToggle(true)
    .ShowRefresh(true)
    .SidePagination(BsMvc.Widgets.Grid.EPagination.CLIENT)
    .Render())
```

- Make sure that your "/Home/GetData" method is returning response in valid json format. 
