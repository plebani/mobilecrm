
if(typeof DayPilot==='undefined'){var DayPilot={};};if(typeof DayPilotMenu==='undefined'){var DayPilotMenu=DayPilot.MenuVisible={};};(function(){if(typeof DayPilot.Menu!=='undefined'){return;};var DayPilotMenu={};DayPilotMenu.mouse=null;DayPilotMenu.menu=null;DayPilotMenu.clickRegistered=false;DayPilotMenu.Menu=function($a){this.zIndex=10;this.useShadow=true;this.cssClassPrefix=null;this.items=$a;this.show=function(e){var $b=(typeof e.value==='function')?e.value():null;if(typeof(DayPilot.Bubble)!=='undefined'){DayPilot.Bubble.hideActive();};DayPilotMenu.menuClean();if(DayPilotMenu.mouse==null)return;var $c=document.createElement("div");$c.style.position="absolute";$c.style.top="0px";$c.style.left="0px";$c.style.display='none';$c.style.overflow='hidden';$c.style.zIndex=this.zIndex+1;$c.className=this.applyCssClass('main');$c.onclick=function(){this.parentNode.removeChild(this);};if(this.items===null||this.items.length===0){throw "No menu items defined.";};if(this.showMenuTitle){var title=document.createElement("div");title.innerHTML=this.menuTitle;title.className=this.applyCssClass("title");$c.appendChild(title);};for(var i=0;i<this.items.length;i++){var mi=this.items[i];var $d=document.createElement("div");if(typeof mi=='undefined'){continue;};if(mi.text=='-'){var $e=document.createElement("div");$d.appendChild($e);}else{var $f=document.createElement("a");$f.style.position='relative';$f.style.display="block";if(mi.href){$f.href=mi.href.replace(/\x7B0\x7D/gim,$b);}else if(mi.onclick){$f.item=mi;$f.onclick=mi.onclick;}else if(mi.command){var $g=function(mi,$f){return function(){var $h=$f.source;var $d=mi;$d.action=$d.action?$d.action:'CallBack';var $i=$h.calendar||$h.root;switch($h.type){case 'resource':$i.resourceHeaderMenuClick($d.command,$h,$d.action);return;case 'selection':$i.timeRangeMenuClick($d.command,$h,$d.action);return;default:$i.eventMenuClick($d.command,$h,$d.action);return;}};};$f.onclick=$g(mi,$f);};$f.source=e;var $j=document.createElement("span");$j.innerHTML=mi.text;$f.appendChild($j);if(mi.image){var $k=document.createElement("img");$k.src=mi.image;$k.style.position='absolute';$k.style.top='0px';$k.style.left='0px';$f.appendChild($k);};$d.appendChild($f);};$c.appendChild($d);};$c.onclick=function(e){window.setTimeout(function(){DayPilotMenu.menuClean();},100);};$c.onmousedown=function(e){if(!e)var e=window.event;e.cancelBubble=true;if(e.stopPropagation)e.stopPropagation();};$c.oncontextmenu=function(){return false;};document.body.appendChild($c);$c.style.display='';var $l=$c.clientHeight;var $m=$c.offsetWidth;$c.style.display='none';var $n=document.documentElement.clientHeight;if(DayPilotMenu.mouse.clientY>$n-$l&&$n!=0){var $o=DayPilotMenu.mouse.clientY-($n-$l)+5;$c.style.top=(DayPilotMenu.mouse.y-$o)+'px';}else{$c.style.top=DayPilotMenu.mouse.y+'px';};var $p=document.documentElement.clientWidth;if(DayPilotMenu.mouse.clientX>$p-$m&&$p!=0){var $q=DayPilotMenu.mouse.clientX-($p-$m)+5;$c.style.left=(DayPilotMenu.mouse.x-$q)+'px';}else{$c.style.left=DayPilotMenu.mouse.x+'px';};$c.style.display='';this.addShadow($c);this.div=$c;DayPilot.Menu.active=this;return;};this.applyCssClass=function($r){if(this.cssClassPrefix){return this.cssClassPrefix+$r;}else{return "";}};this.addShadow=function($s){if(!this.useShadow){return;};if(!$s){return;};if(this.shadows&&this.shadows.length>0){this.removeShadow();};this.shadows=[];for(var i=0;i<5;i++){var $t=document.createElement('div');$t.style.position='absolute';$t.style.width=$s.offsetWidth+'px';$t.style.height=$s.offsetHeight+'px';$t.style.top=$s.offsetTop+i+'px';$t.style.left=$s.offsetLeft+i+'px';$t.style.zIndex=this.zIndex;$t.style.filter='alpha(opacity:10)';$t.style.opacity=0.1;$t.style.backgroundColor='#000000';document.body.appendChild($t);this.shadows.push($t);}};this.removeShadow=function(){if(!this.shadows){return;};for(var i=0;i<this.shadows.length;i++){document.body.removeChild(this.shadows[i]);};this.shadows=[];};DayPilot.re(document.body,'mousemove',DayPilotMenu.mouseMove);if(!DayPilotMenu.clickRegistered){DayPilot.re(document,'mousedown',DayPilotMenu.menuClean);DayPilotMenu.clickRegistered=true;}};DayPilotMenu.click=function($c,$u,$v){var $w=$c.parentNode;if(!$w){return false;};var $s=$w.object;if(!$s){return false;};var $i=$s.calendar||$s.root;switch($s.type){case 'resource':$i.resourceHeaderMenuClick($u,$s,$v);break;case 'selection':$i.timeRangeMenuClick($u,$s,$v);break;default:$i.eventMenuClick($u,$s,$v);break;};return false;};DayPilotMenu.menuClean=function(ev){if(typeof(DayPilot.Menu.active)=='undefined')return;if(DayPilot.Menu.active){DayPilot.Menu.active.removeShadow();document.body.removeChild(DayPilot.Menu.active.div);DayPilot.Menu.active=null;}};DayPilotMenu.mouseMove=function(ev){if(typeof(DayPilotMenu)==='undefined')return;DayPilotMenu.mouse=DayPilotMenu.mousePosition(ev);};DayPilotMenu.mousePosition=function(e){var $x=0;var $y=0;if(!e)var e=window.event;if(e.pageX||e.pageY){$x=e.pageX;$y=e.pageY;}else if(e.clientX||e.clientY){$x=e.clientX+document.body.scrollLeft+document.documentElement.scrollLeft;$y=e.clientY+document.body.scrollTop+document.documentElement.scrollTop;};var $z={};$z.x=$x;$z.y=$y;$z.clientY=e.clientY;$z.clientX=e.clientX;return $z;};DayPilot.MenuVisible.Menu=DayPilotMenu.Menu;DayPilot.Menu=DayPilotMenu.Menu;})();


