/*
 * Ext JS Library 2.2
 * Copyright(c) 2006-2008, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */

Ext.menu.EditableItem = Ext.extend(Ext.menu.BaseItem, {
    itemCls: "x-menu-item",
    hideOnClick: false,

    initComponent: function() {
        Ext.menu.EditableItem.superclass.initComponent.call(this);
        this.addEvents('keyup');

        this.editor = this.editor || new Ext.form.TextField();
        if (this.text) {
            this.editor.setValue(this.text);
        }
    },

    onRender: function(container) {
        var s = container.createChild({
            cls: this.itemCls,
            html: '<img src="' + (this.icon || Ext.BLANK_IMAGE_URL) + '" class="x-menu-item-icon' + (this.iconCls ? ' ' + this.iconCls : '') + '" style="margin: 3px 7px 2px 2px;" />'
        });

        Ext.apply(this.config, { width: 125 });
        this.editor.render(s);

        this.el = s;
        this.relayEvents(this.editor.el, ["keyup"]);

        this.el.swallowEvent(['keydown', 'keypress']);
        Ext.each(["keydown", "keypress"], function(eventName) {
            this.el.on(eventName, function(e) {
                if (e.isNavKeyPress())
                    e.stopPropagation();
            }, this);
        }, this);

        if (Ext.isGecko) {
            s.setOverflow('auto');
            var containerSize = container.getSize();
            this.editor.getEl().setStyle('position', 'fixed');
            container.setSize(containerSize);
        }


        Ext.menu.EditableItem.superclass.onRender.call(this, container);
    },

    getValue: function() {
        return this.editor.getValue();
    },

    setValue: function(value) {
        this.editor.setValue(value);
    },

    isValid: function(preventMark) {
        return this.editor.isValid(preventMark);
    }
});

Ext.menu.RangeMenu = function(config){
	Ext.menu.RangeMenu.superclass.constructor.call(this, config);
  
	this.updateTask = new Ext.util.DelayedTask(this.fireUpdate, this);

	var cfg = this.fieldCfg;
	var cls = this.fieldCls;
	var fields = this.fields = Ext.applyIf(this.fields || {}, {
		'gt': new Ext.menu.EditableItem({
			iconCls:  this.icons.gt,
			editor: new cls(typeof cfg == "object" ? cfg.gt || '' : cfg)
    }),
		'lt': new Ext.menu.EditableItem({
		    iconCls:  this.icons.lt,
			editor: new cls(typeof cfg == "object" ? cfg.lt || '' : cfg)
    }),
		'eq': new Ext.menu.EditableItem({
			iconCls:   this.icons.eq, 
			editor: new cls(typeof cfg == "object" ? cfg.gt || '' : cfg)
    })
	});
	this.add(fields.gt, fields.lt, '-', fields.eq);
	
	for(var key in fields) {
		fields[key].on('keyup', this.onKeyUp.createDelegate(this, [fields[key]], true), this);
  }
  
	this.addEvents('update');
};

Ext.extend(Ext.menu.RangeMenu, Ext.menu.Menu, {
	fieldCls:     Ext.form.NumberField,
	fieldCfg:     '',
	updateBuffer: 500,
	icons: {
		gt: 'ux-rangemenu-gt', 
		lt: 'ux-rangemenu-lt',
		eq: 'ux-rangemenu-eq'
  },
		
	fireUpdate: function() {
		this.fireEvent("update", this);
	},
	
	setValue: function(data) {
		for(var key in this.fields) {
			this.fields[key].setValue(data[key] !== undefined ? data[key] : '');
    }
		this.fireEvent("update", this);
	},
	
	getValue: function() {
		var result = {};
		for(var key in this.fields) {
			var field = this.fields[key];
			if(field.isValid() && String(field.getValue()).length > 0) { 
				result[key] = field.getValue();
      }
		}
		
		return result;
	},
  
  onKeyUp: function(event, input, notSure, field) {
    if(event.getKey() == event.ENTER && field.isValid()) {
	    this.hide(true);
	    return;
	  }
	
	  if(field == this.fields.eq) {
	    this.fields.gt.setValue(null);
	    this.fields.lt.setValue(null);
	  } else {
	    this.fields.eq.setValue(null);
	  }
	  
	  this.updateTask.delay(this.updateBuffer);
  }
});

Ext.menu.ListMenu = function(cfg){
	this.addEvents('checkchanged');
	Ext.menu.ListMenu.superclass.constructor.call(this, cfg = cfg || {});

	if(!cfg.store && cfg.options){
		var options = [];
		for(var i=0, len=cfg.options.length; i<len; i++){
			var value = cfg.options[i];
			switch(Ext.type(value)){
				case 'array':  options.push(value); break;
				case 'object': options.push([value.id, value[this.labelField]]); break;
				case 'string': options.push([value, value]); break;
			}
		}
		
		this.store = new Ext.data.Store({
			reader: new Ext.data.ArrayReader({id: 0}, ['id', this.labelField]),
			data:   options,
			listeners: {
				'load': this.onLoad,
				scope:  this
			}
		});
		this.loaded = true;
	} else {
		this.add({text: this.loadingText, iconCls: 'loading-indicator'});
		this.store.on('load', this.onLoad, this);
	}
};
Ext.extend(Ext.menu.ListMenu, Ext.menu.Menu, {
	labelField:  'text',
	loadingText: 'Loading...',
	loadOnShow:  true,
	single:      false,
	selected:    [],
	
	/**
	 * Lists will initially show a 'loading' item while the data is retrieved from the store. In some cases the
	 * loaded data will result in a list that goes off the screen to the right (as placement calculations were done
	 * with the loading item). This adaptor will allow show to be called with no arguments to show with the previous
	 * arguments and thusly recalculate the width and potentially hang the menu from the left.
	 * 
	 */
	show: function(){
		var lastArgs = null;
		return function(){
			if(arguments.length == 0){
				Ext.menu.ListMenu.superclass.show.apply(this, lastArgs);
			} else {
				lastArgs = arguments;
				if(this.loadOnShow && !this.loaded) this.store.load();
				Ext.menu.ListMenu.superclass.show.apply(this, arguments);
			}
		};
	}(),
	
	onLoad: function(store, records){
		var visible = this.isVisible();
		this.hide(false);
		
		this.removeAll();
		
		var gid = this.single ? Ext.id() : null;
		for(var i=0, len=records.length; i<len; i++){
			var item = new Ext.menu.CheckItem({
				text:    records[i].get(this.labelField), 
				group:   gid,
				checked: this.selected.indexOf(records[i].id) > -1,
				hideOnClick: false});
			
			item.itemId = records[i].id;
			item.on('checkchange', this.checkChange, this);
						
			this.add(item);
		}
		
		this.loaded = true;
		
		if(visible)
			this.show();
			
		this.fireEvent('load', this, records);
	},
	
	setSelected: function(value){
		var value = this.selected = [].concat(value);

		if(this.loaded)
			this.items.each(function(item){
				item.setChecked(false, true);
				for(var i=0, len=value.length; i<len; i++)
					if(item.itemId == value[i]) 
						item.setChecked(true, true);
			}, this);
	},
	
	checkChange: function(item, checked){
		var value = [];
		this.items.each(function(item){
			if(item.checked)
				value.push(item.itemId);
		},this);
		this.selected = value;
		
		this.fireEvent("checkchange", item, checked);
	},
	
	getSelected: function(){
		return this.selected;
	}
});

Ext.grid.GridFilters = function(config){		
	this.filters = new Ext.util.MixedCollection();
	this.filters.getKey = function(o) {return o ? o.dataIndex : null};
	
	for(var i=0, len=config.filters.length; i<len; i++) {
		this.addFilter(config.filters[i]);
  }
  
	this.deferredUpdate = new Ext.util.DelayedTask(this.reload, this);
	
	delete config.filters;
	Ext.apply(this, config);
};
Ext.extend(Ext.grid.GridFilters, Ext.util.Observable, {
    /**
    * @cfg {Integer} updateBuffer
    * Number of milisecond to defer store updates since the last filter change.
    */
    updateBuffer: 500,
    /**
    * @cfg {String} paramPrefix
    * The url parameter prefix for the filters.
    */
    paramPrefix: 'gridfilters',
    /**
    * @cfg {String} fitlerCls
    * The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'
    */
    filterCls: 'ux-filtered-column',
    /**
    * @cfg {Boolean} local
    * True to use Ext.data.Store filter functions instead of server side filtering.
    */
    local: false,
    /**
    * @cfg {Boolean} autoReload
    * True to automagicly reload the datasource when a filter change happens.
    */
    autoReload: true,
    /**
    * @cfg {String} stateId
    * Name of the Ext.data.Store value to be used to store state information.
    */
    stateId: undefined,
    /**
    * @cfg {Boolean} showMenu
    * True to show the filter menus
    */
    showMenu: true,
    /**
    * @cfg {String} filtersText
    * The text displayed for the "Filters" menu item
    */
    filtersText: 'Filters',
    isGridFiltersPlugin: true,

    init: function(grid) {
        if (grid instanceof Ext.grid.GridPanel) {
            this.grid = grid;

            this.store = this.grid.getStore();
            if (this.local) {
                this.store.on('load', function(store) {
                    store.filterBy(this.getRecordFilter());
                }, this);
            } else {
                this.store.on('beforeload', this.onBeforeLoad, this);
            }

            this.grid.filters = this;

            this.grid.addEvents('filterupdate');

            grid.on("render", this.onRender, this);
            grid.on("beforestaterestore", this.applyState, this);
            grid.on("beforestatesave", this.saveState, this);

        } else if (grid instanceof Ext.PagingToolbar) {
            this.toolbar = grid;
        }
    },

    /** private **/
    applyState: function(grid, state) {
        this.suspendStateStore = true;
        this.clearFilters();
        if (state.filters) {
            for (var key in state.filters) {
                var filter = this.filters.get(key);
                if (filter) {
                    filter.setValue(state.filters[key]);
                    filter.setActive(true);
                }
            }
        }

        this.deferredUpdate.cancel();
        if (this.local) {
            this.reload();
        }

        this.suspendStateStore = false;
    },

    /** private **/
    saveState: function(grid, state) {
        var filters = {};
        this.filters.each(function(filter) {
            if (filter.active) {
                filters[filter.dataIndex] = filter.getValue();
            }
        });
        return state.filters = filters;
    },

    /** private **/
    onRender: function() {
        var hmenu;

        if (this.showMenu) {
            hmenu = this.grid.getView().hmenu;

            this.sep = hmenu.addSeparator();
            this.menu = hmenu.add(new Ext.menu.CheckItem({
                text: this.filtersText,
                menu: new Ext.menu.Menu()
            }));
            this.menu.on('checkchange', this.onCheckChange, this);
            this.menu.on('beforecheckchange', this.onBeforeCheck, this);

            hmenu.on('beforeshow', this.onMenu, this);
        }

        this.grid.getView().on("refresh", this.onRefresh, this);
        this.updateColumnHeadings(this.grid.getView());
    },

    /** private **/
    onMenu: function(filterMenu) {
        var filter = this.getMenuFilter();
        if (filter) {
            this.menu.menu = filter.menu;
            this.menu.setChecked(filter.active, false);
        }

        this.menu.setVisible(filter !== undefined);
        this.sep.setVisible(filter !== undefined);
    },

    /** private **/
    onCheckChange: function(item, value) {
        this.getMenuFilter().setActive(value);
    },

    /** private **/
    onBeforeCheck: function(check, value) {
        return !value || this.getMenuFilter().isActivatable();
    },

    /** private **/
    onStateChange: function(event, filter) {
        if (event == "serialize") {
            return;
        }

        if (filter == this.getMenuFilter()) {
            this.menu.setChecked(filter.active, false);
        }

        if (this.autoReload || this.local) {
            this.deferredUpdate.delay(this.updateBuffer);
        }

        var view = this.grid.getView();
        this.updateColumnHeadings(view);

        this.grid.saveState();

        this.grid.fireEvent('filterupdate', this, filter);
    },

    /** private **/

    isEmptyObject: function(object) {
        if (!(object && typeof object == "object")) { return false; }
        for (var p in object) { return false; }
        return true;
    },


    onBeforeLoad: function(store, options) {
        options.params = options.params || {};
        this.cleanParams(options.params[this.paramPrefix] || {});
        var params = this.buildQuery(this.getFilterData());
        var filterParams = {};

        if (!this.isEmptyObject(params)) {
            filterParams[this.paramPrefix] = params;
        }

        Ext.apply(options.params, filterParams);
    },

    /** private **/
    onRefresh: function(view) {
        this.updateColumnHeadings(view);
    },

    /** private **/
    getMenuFilter: function() {
        var view = this.grid.getView();
        if (!view || view.hdCtxIndex === undefined) {
            return null;
        }

        return this.filters.get(view.cm.config[view.hdCtxIndex].dataIndex);
    },

    /** private **/
    updateColumnHeadings: function(view) {
        if (!view || !view.mainHd) {
            return;
        }

        var hds = view.mainHd.select('td').removeClass(this.filterCls);
        for (var i = 0, len = view.cm.config.length; i < len; i++) {
            var filter = this.getFilter(view.cm.config[i].dataIndex);
            if (filter && filter.active) {
                hds.item(i).addClass(this.filterCls);
            }
        }
    },

    /** private **/
    reload: function() {
        if (this.local) {
            this.grid.store.clearFilter(true);
            this.grid.store.filterBy(this.getRecordFilter());
        } else {
            this.deferredUpdate.cancel();
            var store = this.grid.store;
            this.clearTBar();
            store.reload(undefined, true);
        }
    },

    clearTBar: function() {
        var startName = null;
        var store = this.grid.store;
        if (this.grid.getBottomToolbar() instanceof Ext.PagingToolbar) {
            startName = this.grid.getBottomToolbar().paramNames.start
        }
        else if (this.grid.getTopToolbar() instanceof Ext.PagingToolbar) {
            startName = this.grid.getTopToolbar().paramNames.start
        }

        if (startName != null) {
            if (store.lastOptions && store.lastOptions.params && store.lastOptions.params[startName]) {
                store.lastOptions.params[startName] = 0;
            }
        }
    },

    /**
    * Method factory that generates a record validator for the filters active at the time
    * of invokation.
    * 
    * @private
    */
    getRecordFilter: function() {
        var f = [];
        this.filters.each(function(filter) {
            if (filter.active) {
                f.push(filter);
            }
        });

        var len = f.length;
        return function(record) {
            for (var i = 0; i < len; i++) {
                if (!f[i].validateRecord(record)) {
                    return false;
                }
            }
            return true;
        };
    },

    /**
    * Adds a filter to the collection.
    * 
    * @param {Object/Ext.grid.filter.Filter} config A filter configuration or a filter object.
    * 
    * @return {Ext.grid.filter.Filter} The existing or newly created filter object.
    */
    addFilter: function(config) {
        var filter = config.menu ? config : new (this.getFilterClass(config.type))(config);
        this.filters.add(filter);

        Ext.util.Observable.capture(filter, this.onStateChange, this);
        return filter;
    },

    /**
    * Returns a filter for the given dataIndex, if on exists.
    * 
    * @param {String} dataIndex The dataIndex of the desired filter object.
    * 
    * @return {Ext.grid.filter.Filter}
    */
    getFilter: function(dataIndex) {
        return this.filters.get(dataIndex);
    },

    /**
    * Turns all filters off. This does not clear the configuration information.
    */
    clearFilters: function() {
        this.filters.each(function(filter) {
            filter.setActive(false);
        });
    },

    /** private **/
    getFilterData: function() {
        var filters = [];

        this.filters.each(function(f) {
            if (f.active) {
                var d = [].concat(f.serialize());
                for (var i = 0, len = d.length; i < len; i++) {
                    filters.push({ field: f.dataIndex, data: d[i] });
                }
            }
        });

        return filters;
    },

    getFilterValues: function() {
        var filters = [];

        this.filters.each(function(f) {
            if (f.active) {
                filters.push({ field: f.dataIndex, value: f.getValue() });
            }
        });

        return filters;
    },

    /**
    * Function to take structured filter data and 'flatten' it into query parameteres. The default function
    * will produce a query string of the form:
    * 		filters[0][field]=dataIndex&filters[0][data][param1]=param&filters[0][data][param2]=param...
    * 
    * @param {Array} filters A collection of objects representing active filters and their configuration.
    * 	  Each element will take the form of {field: dataIndex, data: filterConf}. dataIndex is not assured
    *    to be unique as any one filter may be a composite of more basic filters for the same dataIndex.
    * 
    * @return {Object} Query keys and values
    */
    buildQuery: function(filters) {
        if (this.store.proxy.refreshByUrl) {
            return this.getRecordFilter();
        }
        var p = {};
        for (var i = 0, len = filters.length; i < len; i++) {
            var f = filters[i];
            var root = ['f_', i, '_'].join('');
            p[root + 'field'] = f.field;

            var dataPrefix = root + 'data_';
            for (var key in f.data) {
                p[[dataPrefix, key].join('')] = f.data[key];
            }
        }

        return p;
    },

    /**
    * Removes filter related query parameters from the provided object.
    * 
    * @param {Object} p Query parameters that may contain filter related fields.
    */
    cleanParams: function(p) {
        var regex = new RegExp("^f\_[0-9]+\_");
        for (var key in p) {
            if (regex.test(key)) {
                delete p[key];
            }
        }
    },

    /**
    * Function for locating filter classes, overwrite this with your favorite
    * loader to provide dynamic filter loading.
    * 
    * @param {String} type The type of filter to load.
    * 
    * @return {Class}
    */
    getFilterClass: function(type) {
        return Ext.grid.filter[type.substr(0, 1).toUpperCase() + type.substr(1) + 'Filter'];
    }
});

Ext.ns("Ext.grid.filter");
Ext.grid.filter.Filter = function(config){
	Ext.apply(this, config);
		
	this.events = {
		/**
		 * @event activate
		 * Fires when a inactive filter becomes active
		 * @param {Ext.ux.grid.filter.Filter} this
		 */
		'activate': true,
		/**
		 * @event deactivate
		 * Fires when a active filter becomes inactive
		 * @param {Ext.ux.grid.filter.Filter} this
		 */
		'deactivate': true,
		/**
		 * @event update
		 * Fires when a filter configuration has changed
		 * @param {Ext.ux.grid.filter.Filter} this
		 */
		'update': true,
		/**
		 * @event serialize
		 * Fires after the serialization process. Use this to apply additional parameters to the serialized data.
		 * @param {Array/Object} data A map or collection of maps representing the current filter configuration.
		 * @param {Ext.ux.grid.filter.Filter} filter The filter being serialized.
		 **/
		'serialize': true
	};
	Ext.grid.filter.Filter.superclass.constructor.call(this);
	
	this.menu = new Ext.menu.Menu();
	this.init(config);

	if (config && !Ext.isEmpty(config.value, false)) {
		this.setValue(config.value);
		this.setActive(config.active !== false, true);
		delete config.value;
	}
};
Ext.extend(Ext.grid.filter.Filter, Ext.util.Observable, {
	/**
	 * @cfg {Boolean} active
	 * Indicates the default status of the filter (defaults to false).
	 */
    /**
     * True if this filter is active. Read-only.
     * @type Boolean
     * @property
     */
	active: false,
	/**
	 * @cfg {String} dataIndex 
	 * The {@link Ext.data.Store} data index of the field this filter represents. The dataIndex does not actually
	 * have to exist in the store.
	 */
	dataIndex: null,
	/**
	 * The filter configuration menu that will be installed into the filter submenu of a column menu.
	 * @type Ext.menu.Menu
	 * @property
	 */
	menu: null,
	
	/**
	 * @cfg {Number} updateBuffer
	 * Some filters may wait a short time after user interaction to fire an update.
	 */
	updateBuffer: 500,
	
	/**
	 * Initialize the filter and install required menu items.
	 */
	init: Ext.emptyFn,
	
	fireUpdate: function() {
				
		if(this.active) {
			this.fireEvent("update", this);
        }
	    this.setActive(this.isActivatable());
	},
	
	/**
	 * Returns true if the filter has enough configuration information to be activated.
	 * @return {Boolean}
	 */
	isActivatable: function() {
		return true;
	},
	
	/**
	 * Sets the status of the filter and fires that appropriate events.
	 * @param {Boolean} active        The new filter state.
	 * @param {Boolean} suppressEvent True to prevent events from being fired.
	 */
	setActive: function(active, suppressEvent) {
		if(this.active != active) {
			this.active = active;
			if(suppressEvent !== true) {
				this.fireEvent(active ? 'activate' : 'deactivate', this);
      }
		}
	},
	
	/**
	 * Get the value of the filter
	 * @return {Object} The 'serialized' form of this filter
	 */
	getValue: Ext.emptyFn,
	
	/**
	 * Set the value of the filter.
	 * @param {Object} data The value of the filter
	 */	
	setValue: Ext.emptyFn,
	
	/**
	 * Serialize the filter data for transmission to the server.
	 * @return {Object/Array} An object or collection of objects containing key value pairs representing
	 * 	the current configuration of the filter.
	 */
	serialize: Ext.emptyFn,
	
	/**
	 * Validates the provided Ext.data.Record against the filters configuration.
	 * @param {Ext.data.Record} record The record to validate
	 * @return {Boolean} True if the record is valid with in the bounds of the filter, false otherwise.
	 */
	 validateRecord: function(){return true;}
});

Ext.grid.filter.StringFilter = Ext.extend(Ext.grid.filter.Filter, {

    icon: 'ux-gridfilter-text-icon',

    init: function() {
        var value = this.value = new Ext.menu.EditableItem({ iconCls: this.icon });
        value.on('keyup', this.onKeyUp, this);
        this.menu.add(value);

        this.updateTask = new Ext.util.DelayedTask(this.fireUpdate, this);
    },

    onKeyUp: function(event) {
        if (event.getKey() == event.ENTER) {
            this.menu.hide(true);
            return;
        }
        this.updateTask.delay(this.updateBuffer);
    },

    isActivatable: function() {
        return this.value.getValue().length > 0;
    },

    fireUpdate: function() {
        if (this.active) {
            this.fireEvent("update", this);
        }
        this.setActive(this.isActivatable());
    },

    setValue: function(value) {
        this.value.setValue(value);
        this.fireEvent("update", this);
    },

    getValue: function() {
        return this.value.getValue();
    },

    serialize: function() {
        var args = { type: 'string', value: this.getValue() };
        this.fireEvent('serialize', args, this);
        return args;
    },

    validateRecord: function(record) {
        var val = record.get(this.dataIndex);
        if (typeof val != "string") {
            return this.getValue().length == 0;
        }
        if (Ext.isEmpty(val, true)) {
            val = "";
        }
        return val.toLowerCase().indexOf(this.getValue().toLowerCase()) > -1;
    }
});

Ext.grid.filter.DateFilter = Ext.extend(Ext.grid.filter.Filter, {
    /**
    * @cfg {Date} dateFormat
    * The date format applied to the menu's {@link Ext.menu.DateMenu}
    */
    dateFormat: 'm/d/Y',
    /**
    * @cfg {Object} pickerOpts
    * The config object that will be passed to the menu's {@link Ext.menu.DateMenu} during
    * initialization (sets minDate, maxDate and format to the same configs specified on the filter)
    */
    pickerOpts: {},
    /**
    * @cfg {String} beforeText
    * The text displayed for the "Before" menu item
    */
    beforeText: 'Before',
    /**
    * @cfg {String} afterText
    * The text displayed for the "After" menu item
    */
    afterText: 'After',
    /**
    * @cfg {String} onText
    * The text displayed for the "On" menu item
    */
    onText: 'On',
    /**
    * @cfg {Date} minDate
    * The minimum date allowed in the menu's {@link Ext.menu.DateMenu}
    */
    /**
    * @cfg {Date} maxDate
    * The maximum date allowed in the menu's {@link Ext.menu.DateMenu}
    */

    init: function() {
        var opts = Ext.apply(this.pickerOpts, {
            minDate: this.minDate,
            maxDate: this.maxDate,
            format: this.dateFormat
        });
        var dates = this.dates = {
            'before': new Ext.menu.CheckItem({ text: this.beforeText, menu: new Ext.menu.DateMenu(opts) }),
            'after': new Ext.menu.CheckItem({ text: this.afterText, menu: new Ext.menu.DateMenu(opts) }),
            'on': new Ext.menu.CheckItem({ text: this.onText, menu: new Ext.menu.DateMenu(opts) })
        };

        this.menu.add(dates.before, dates.after, "-", dates.on);

        for (var key in dates) {
            var date = dates[key];
            date.menu.on('select', this.onSelect.createDelegate(this, [date]), this);

            date.on('checkchange', function() {
                this.setActive(this.isActivatable());
            }, this);
        };
    },

    onSelect: function(date, menuItem, value, picker) {
        date.setChecked(true);
        var dates = this.dates;

        if (date == dates.on) {
            dates.before.setChecked(false, true);
            dates.after.setChecked(false, true);
        } else {
            dates.on.setChecked(false, true);

            if (date == dates.after && dates.before.menu.picker.value < value) {
                dates.before.setChecked(false, true);
            } else if (date == dates.before && dates.after.menu.picker.value > value) {
                dates.after.setChecked(false, true);
            }
        }

        this.fireEvent("update", this);
    },

    getFieldValue: function(field) {
        return this.dates[field].menu.picker.getValue();
    },

    getPicker: function(field) {
        return this.dates[field].menu.picker;
    },

    isActivatable: function() {
        return this.dates.on.checked || this.dates.after.checked || this.dates.before.checked;
    },

    setValue: function(value) {
        for (var key in this.dates) {
            if (value[key]) {
                this.dates[key].menu.picker.setValue(value[key]);
                this.dates[key].setChecked(true);
            } else {
                this.dates[key].setChecked(false);
            }
        }
    },

    getValue: function() {
        var result = {};
        for (var key in this.dates) {
            if (this.dates[key].checked) {
                result[key] = this.dates[key].menu.picker.getValue();
            }
        }
        return result;
    },

    serialize: function() {
        var args = [];
        if (this.dates.before.checked) {
            args = [{ type: 'date', comparison: 'lt', value: this.getFieldValue('before').dateFormat(this.dateFormat)}];
        }
        if (this.dates.after.checked) {
            args.push({ type: 'date', comparison: 'gt', value: this.getFieldValue('after').dateFormat(this.dateFormat) });
        }
        if (this.dates.on.checked) {
            args = { type: 'date', comparison: 'eq', value: this.getFieldValue('on').dateFormat(this.dateFormat) };
        }

        this.fireEvent('serialize', args, this);
        return args;
    },

    validateRecord: function(record) {
        var rDate = record.get(this.dataIndex);
        if (Ext.isEmpty(rDate)) {
            return false;
        }
        var val = rDate.clearTime(true).getTime();

        if (this.dates.on.checked && val != this.getFieldValue('on').clearTime(true).getTime()) {
            return false;
        }
        if (this.dates.before.checked && val >= this.getFieldValue('before').clearTime(true).getTime()) {
            return false;
        }
        if (this.dates.after.checked && val <= this.getFieldValue('after').clearTime(true).getTime()) {
            return false;
        }
        return true;
    }
});

Ext.grid.filter.ListFilter = Ext.extend(Ext.grid.filter.Filter, {

	phpMode:     false,
	
		init: function(config){
		this.dt = new Ext.util.DelayedTask(this.fireUpdate, this);

		this.menu = new Ext.menu.ListMenu(config);
		this.menu.on('checkchange', this.onCheckChange, this);
	},
	
	onCheckChange: function(){
		this.dt.delay(this.updateBuffer);
	},
	
	isActivatable: function(){
		return this.menu.getSelected().length > 0;
	},
	
	setValue: function(value){
		this.menu.setSelected(value);
			
		this.fireEvent("update", this);
	},
	
	getValue: function(){
		return this.menu.getSelected();
	},
	
	serialize: function(){
	    var args = {type: 'list', value: this.phpMode ? this.getValue().join(',') : this.getValue()};
	    this.fireEvent('serialize', args, this);
		
		return args;
	},
	
	validateRecord: function(record){
		return this.getValue().indexOf(record.get(this.dataIndex)) > -1;
	}

});

Ext.grid.filter.NumericFilter = Ext.extend(Ext.grid.filter.Filter, {
	init: function() {
		this.menu = new Ext.menu.RangeMenu({updateBuffer: this.updateBuffer});
		
		this.menu.on("update", this.fireUpdate, this);
	},
	
	fireUpdate: function() {
		this.setActive(this.isActivatable());
		this.fireEvent("update", this);
	},
	
	isActivatable: function() {
		var value = this.menu.getValue();
		return value.eq !== undefined || value.gt !== undefined || value.lt !== undefined;
	},
	
	setValue: function(value) {
		this.menu.setValue(value);
	},
	
	getValue: function() {
		return this.menu.getValue();
	},
	
	serialize: function() {
		var args = [];
		var values = this.menu.getValue();
		for(var key in values) {
			args.push({type: 'numeric', comparison: key, value: values[key]});
    }
		this.fireEvent('serialize', args, this);
		return args;
	},
	
	validateRecord: function(record) {
		var val = record.get(this.dataIndex),
			values = this.menu.getValue();
			
		if(values.eq != undefined && val != values.eq) {
			return false;
    }
		if(values.lt != undefined && val >= values.lt) {
			return false;
    }
		if(values.gt != undefined && val <= values.gt) {
			return false;
    }
		return true;
	}
});

Ext.grid.filter.BooleanFilter = Ext.extend(Ext.grid.filter.Filter, {
    /**
     * @cfg {Boolean} defaultValue
     * The default value of this filter (defaults to false)
     */
    defaultValue: false,
    /**
     * @cfg {String} yesText
     * The text displayed for the "Yes" checkbox
     */
    yesText: 'Yes',
    /**
     * @cfg {String} noText
     * The text displayed for the "No" checkbox
     */
    noText: 'No',

	init: function(){
	    var gId = Ext.id();
			this.options = [
				new Ext.menu.CheckItem({text: this.yesText, group: gId, checked: this.defaultValue === true}),
				new Ext.menu.CheckItem({text: this.noText, group: gId, checked: this.defaultValue === false})
	    ];
		
		this.menu.add(this.options[0], this.options[1]);
		
		for(var i=0; i<this.options.length; i++) {
			this.options[i].on('click', this.fireUpdate, this);
			this.options[i].on('checkchange', this.fireUpdate, this);
		}
	},
	
	isActivatable: function() {
		return true;
	},
	
	fireUpdate: function() {		
		this.fireEvent("update", this);			
		this.setActive(true);
	},
	
	setValue: function(value) {
		this.options[value ? 0 : 1].setChecked(true);
	},
	
	getValue: function() {
		return this.options[0].checked;
	},
	
	serialize: function() {
		var args = {type: 'boolean', value: this.getValue()};
		this.fireEvent('serialize', args, this);
		return args;
	},
	
	validateRecord: function(record) {
		return record.get(this.dataIndex) == this.getValue();
	}
});

if(typeof Sys!=="undefined"){Sys.Application.notifyScriptLoaded();}