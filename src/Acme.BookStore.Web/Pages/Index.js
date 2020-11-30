$(function () {
    var l = abp.localization.getResource('BookStore');

    var dataTable = $('#AuthorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.books.book.getList),
            columnDefs: [

                {
                    data: { name: "name", authorName: "authorName", id: "id" },
                    "render": function (data) {
                        return '<a  href="/BookList?' + data.id + '&type=name"><span class="list_hshv_name">' + data.name + '</a>'
                    }
                }, 

                //{
                //    title: l('Name'),
                //    data: "name"
                //},
                //{
                //    title: l('BirthDate'),
                //    data: "birthDate",
                //    render: function (data) {
                //        return luxon
                //            .DateTime
                //            .fromISO(data, {
                //                locale: abp.localization.currentCulture.name
                //            }).toLocaleString();
                //    }
                //},
                  {
                    title: l('Name'),
                    data: "name"
                },
                // ADDED the NEW AUTHOR NAME COLUMN
                {
                    title: l('Author'),
                    data: "authorName"
                }
            ]
        })
    );
});
