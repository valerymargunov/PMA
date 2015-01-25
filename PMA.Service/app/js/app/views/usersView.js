(function (window, $, _, views) {
    "use strict";

    views.UsersView = views.BaseView.extend({
        templateName: "usersTemplate",
        container: "#sidebar",
        initialize: function () {
        },
        render: function () {
            this.$el.html(_.template(this.getTemplate()));
            $(this.container).html(this.$el);

            return this;
        }
    });
})(window, window.$, window._, window.App.views);