$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Slides/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Slides/EditModal');

    var dataTable = $('#SlidesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.slides.slide.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BookStore.Slides.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },

                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BookStore.Slides.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l(
                                            'SlideDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.slides.slide
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name", render: function (data) {
                        return '<img width="100" height="100" src="slide/' + data + '"/>'
                    },
                },
                {
                    title: l('Title'),
                    data: "title"
                },
                {
                    title: l('Detail'),
                    data: "detail"
                },
                {
                    title: l('Sale'),
                    data: "sale"
                },
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSlideButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
