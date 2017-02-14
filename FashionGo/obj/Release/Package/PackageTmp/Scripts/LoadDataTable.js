
        $(document).ready(function () {
            $('.table').DataTable({
                "dom": 'RC<"clear">lfrtip'
            });

            var table = $('.table').dataTable();
            var tt = new $.fn.dataTable.TableTools(table);
            $(tt.fnContainer()).insertBefore('div.dataTables_wrapper');

        });
