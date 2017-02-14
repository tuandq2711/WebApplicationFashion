
        $(document).ready(function () {
            $(document).on("click", "#contentPager a, #contentPagerFooter a, .contentPager a", function () {
                var page = $(this).text();
                
                if(page=="»" || page=="«")
                {
                    page = $(this).attr("href");
                    page = page.split("=")[1];
                   
                    
                    
                    

                }
                search = $(".search-field").val();
                cat = $("#category").val();
                
                $.ajax({
                    url: "/home/search?page="+page,
                    data: {keywork: search, cat:cat, page:page },
                    type: 'POST',
                    cache: false,
                    success: function (result) {
                       
                        $(".homebanner-holder").html(result).replaceAll();
                    }
                });
                return false;
            });
        });

