
       $(document).ready(function () {
           $("#check-all-header").click(function () {
               var checkedStatus = this.checked;
               $('#domainTable tbody tr').find('td:first :checkbox').each(function () {
                   $(this).prop('checked', checkedStatus);
               });

           });

       });
