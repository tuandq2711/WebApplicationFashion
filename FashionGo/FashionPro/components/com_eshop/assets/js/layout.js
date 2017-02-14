// Function to alternative between list/grid
function changeLayout(layoutType)
{
	if (layoutType == 'list')
	{
		if(jQuery.cookie("product_layout") == 'grid')
		{
			jQuery("#products-list-container").removeClass('list');
			jQuery("#products-list-container").addClass('grid');
		}
		else
		{
			jQuery("#products-list-container").removeClass('grid');
			jQuery("#products-list-container").addClass('list');
		}
	}
	else
	{
		if(jQuery.cookie("product_layout") == 'list')
		{
			jQuery("#products-list-container").removeClass('grid');
			jQuery("#products-list-container").addClass('list');
		}
		else
		{
			jQuery("#products-list-container").removeClass('list');
			jQuery("#products-list-container").addClass('grid');
		}
	}
	jQuery(".sortPagiBar .btn-group a").click(function() {
		if(this.rel == 'list')
		{
			jQuery("#products-list-container").removeClass('grid');
			jQuery("#products-list-container").addClass(this.rel);
			jQuery.cookie("product_layout", "list");
		}
		else
		{
			jQuery("#products-list-container").removeClass('list');
			jQuery("#products-list-container").addClass(this.rel);
			jQuery.cookie("product_layout", "grid");
		}
		return false;
	});
}