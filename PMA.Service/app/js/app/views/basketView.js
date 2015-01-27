(function (window, $, _, views) {
    "use strict";

    views.BasketView = views.BaseView.extend({
        templateName: "basketTemplate",
        container: "#content",
        initialize: function () {
        },
        render: function () {
            this.$el.html(_.template(this.getTemplate()));
            $(this.container).html(this.$el);

            return this;
        }
    });
})(window, window.$, window._, window.App.views);