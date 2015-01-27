(function (global, $, _, Backbone) {
    "use strict";

    global.App = {
        views: {},
        models: {},
        templates: {},
        config: {
            serviceUrl: global.location.origin + "/api/"
        }
    };

    var views = global.App.views,
		models = global.App.models;


    var Router = Backbone.Router.extend({

        initialize: function () {
            //this.views = {};
            //this.noteList = new models.NoteList();

            //this.showView(new views.AdminView());
            //this.noteList.fetch();
        },

        routes: {
            "": "home",
            "note/:id": "note",
            "add-note": "addNote",
            "edit-note/:id": "editNote",
            "administration": "showAdmin",
            "users": "showUsers",
            "adminCategories": "showAdminCategory",
            "adminProducts": "showAdminProducts",
            "products": "showProducts",
            "basket": "showBasket",
        },
        showAdmin: function () {
            this.showView(new views.AdminView());
        },
        showUsers: function () {
            this.showView(new views.UsersView());
        },

        showView: function (view) {
            if (_.has(this.views, view.container)) {
                views[view.container].remove();
            }

            view.render();

            views[view.container] = view;
        }
    });



    $(function () {
        global.app = new Router();
        Backbone.history.start();
        $("#tree").fancytree({
            activate: function (event, data) {
                location.href = location.origin + location.pathname + '#' + data.node.key;
            }
        });
    });
})(window, window.$, window._, window.Backbone);