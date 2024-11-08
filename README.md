## 安装数据库

1. **下载和安装** PostgreSQL 数据库：官方网站[https://www.postgresql.org/download](https://www.postgresql.org/download)下载适合您操作系统的安装程序然后按照安装向导进行安装。

## 安装数据库管理工具

1. 下载和安装 pgAdmin 工具：官方网站[https://www.pgadmin.org/download](https://www.pgadmin.org/download)下载适合您操作系统的 pgAdmin 安装程序。

## 创建数据库迁移

1. 添加数据库迁移脚本。
2. 更新数据库迁移到数据库。

## 迁移数据库

### 新创建数据库

1. 替换配置文件中的 IP 地址为本地地址。
2. 切换到**Hx.BgApp.DbMigrator**作为启动项。
3. 添加数据库迁移：

```
add-migration Init2024-1
```

4. 更新到数据库：

```
update-database
```

5. 启动项目，创建种子数据。
6. 切换回启动项：切换到**Hx.BgApp.Blazor**。

### 更新已有数据库

1. 删除数据库中的结构和数据：

```
update-databse -migration:0
```

查看是否删除数据库，如无法用脚本删除，则需要在数据库管理工具中手动删除数据库。  
2. 移除原有迁移：

```
remove-migration
```

3. 后续步骤与新创建数据库一致。
