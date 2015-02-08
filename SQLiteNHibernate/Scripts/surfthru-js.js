//POP OVERS
$(document).ready(function () {

    //Add Alt Tags
    $("img").each(function () {
        var img = $(this);
        if (!img.attr("alt") || img.attr("alt") == "")
            img.attr("alt", "Asset Allocation Models");
    });

    BindEvents();
});

//---------------------------------
// Handles Init in AJAX Post Backs 
//---------------------------------
function BindEvents() {

    $("img").addClass("img-responsive");


    //See PortfolioAllocations.acx
    //<script type="text/javascript">
    //  Sys.Application.add_load(BindEvents);            
    //</script>
  

    //--- START Popovers with x -----
    $('.popoverThis').popover({
        html: true,
        placement: 'right',
        content: function () {
            return $($(this).data('contentwrapper')).html();
        }
    });
    $('.popoverThis').click(function (e) {
        e.stopPropagation();
    }); 
    $(document).click(function (e) {
        if (($('.popover').has(e.target).length == 0) || $(e.target).is('.close')) {
            $('.popoverThis').popover('hide');
        }
    });

    //POPOVER --- TOP ---
    $('.popoverThisTop').popover({
        html: true,
        placement: 'top',
        content: function () {
            return $($(this).data('contentwrapper')).html();
        }
    });
    $('.popoverThisTop').click(function (e) {
        e.stopPropagation();
    });
    $(document).click(function (e) {
        if (($('.popover').has(e.target).length == 0) || $(e.target).is('.close')) {
            $('.popoverThisTop').popover('hide');
        }
    });

    //--- END Popovers with x -----

    //Accordion
    $('#accordion').on('hidden.bs.collapse', function () {
        //do something...
    })
    $('#accordion .accordion-toggle').click(function (e) {
        var chevState = $(e.target).siblings("i.indicator").toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        $("i.indicator").not(chevState).removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up");
    });

    function SetChevron(PanelID)
    {
        var chevState = $(panel.target).siblings("i.indicator").toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        $("i.indicator").not(chevState).removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up");
    }
}
