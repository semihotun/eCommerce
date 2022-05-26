
function AddDataTableFilterOptionHtml(thisdata) {
    $("#DataTableFilterDropdown").change(function (e) {
        $(this).parent().find("input").val($(this).val());
    })
    var title = $(thisdata).text();
    var filterType = $(thisdata).attr("filterType");
    if (title != " ") {
        switch (filterType) {
            case "int":
                $(thisdata).html(`<div class="d-flex"><input type="text" class="form-control" placeholder="` + title + ` giriniz" />
                            <select id="filter">
                                <option value='1'>Eşit</option>
                                <option value='2'>Eşit Değil</option>
                                <option value='5'>Büyüktür</option>
                                <option value='6'>Küçüktür</option>
                            </select>
                         </div>`);
                break;
            case "string":
                $(thisdata).html(`<div class="d-flex"><input type="text" class="form-control" placeholder="` + title + ` giriniz" />
                            <select id="filter">
                                <option value='1'>Eşittir</option>
                                <option value='2'>Eşit Değil</option>
                                <option value='3'>İçerir</option>
                            </select>
                         </div>`);
                break;
            case "bool":
                $(thisdata).html(`<div class="d-flex">
                            <input type="hidden" class="form-control" placeholder="` + title + ` giriniz" />
                            <select id="filter" class="d-none">
                                <option value='1'>Equals</option>
                            </select>
                            <select id="DataTableFilterDropdown" class="form-control">
                                <option value="true">Evet</option>
                                <option value="false">Hayır</option>
                            </select>
                         </div>`);
                break;
        }

    }
}


function AddDataTableFilter(DataTableVeriable) {

    var dataTableId = "#" + DataTableVeriable.context[0].sTableId;
    $(dataTableId + ' thead tr').clone(true, true).appendTo(dataTableId + ' thead');
    $(dataTableId + ' thead tr:eq(1) th').each(function (i) {
        AddDataTableFilterOptionHtml(this);
        $('input', this).on('keyup change', function () {
            if (DataTableVeriable.column(i).search() !== this.value) {
                var searchData = {
                    Value: this.value,
                    FilterType: $(this).next().val()
                }
                DataTableVeriable
                    .column(i)
                    .search(JSON.stringify(searchData), true)
                    .draw(true);
            }
        });
    });
}
