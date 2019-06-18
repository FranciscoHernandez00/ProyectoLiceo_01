
    $(document).ready(function () {

        var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');

    allWells.hide();

        navListItems.click(function (e) {
        e.preventDefault();
    var $target = $($(this).attr('href')),
        $item = $(this);

            if (!$item.hasClass('disabled')) {
        navListItems.removeClass('btn-primary').addClass('btn-default');
    $item.addClass('btn-primary');
    allWells.hide();
    $target.show();
    $target.find('input:eq(0)').focus();
}
});

        allNextBtn.click(function () {
            var curStep = $(this).closest(".setup-content"),
        curStepBtn = curStep.attr("id"),
        nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
        curInputs = curStep.find("input[type='text'],input[type='url']"),
        isValid = true;

    $(".form-group").removeClass("has-error");
            for (var i = 0; i < curInputs.length; i++) {
                if (!curInputs[i].validity.valid) {
        isValid = false;
    $(curInputs[i]).closest(".form-inline").addClass("has-error");
}
}

if (isValid)
nextStepWizard.removeAttr('disabled').trigger('click');
});

$('div.setup-panel div a.btn-primary').trigger('click');
});

    $(document).ready(function () {

        $('.input').focus(function () {
            $(this).parent().find(".label-txt").addClass('label-active');
        });

    $(".input").focusout(function () {
            if ($(this).val() == '') {
        $(this).parent().find(".label-txt").removeClass('label-active');
    };
});

});

    function check(browser) {
        document.getElementById("answer").value = browser;
    };

    function check(Alex) {
        document.getElementById("alexander").value = Alex;
    };



    function img(x) {
        if (x == 0)
        document.getElementById('myimg').style.display = 'block';
    else
        document.getElementById('myimg').style.display = 'none';
    return;
};